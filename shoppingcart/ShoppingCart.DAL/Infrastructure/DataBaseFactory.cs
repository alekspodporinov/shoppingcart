using System.Threading.Tasks;
using ShoppingCart.DAL.EF;

namespace ShoppingCart.DAL.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ApplicationDbContext _dataContext;
        private readonly string _connectionString;


        public DatabaseFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext Get()
        {
            return _dataContext ?? (_dataContext = new ApplicationDbContext(_connectionString));
        }

        protected override void DisposeObject()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
