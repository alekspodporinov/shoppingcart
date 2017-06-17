using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Threading.Tasks;
using ShoppingCart.DAL.EF;
using ShoppingCart.DAL.Repositories;

namespace ShoppingCart.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private ApplicationDbContext _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        protected ApplicationDbContext DataContext => _dataContext ?? (_dataContext = _databaseFactory.Get());

        public async Task SaveAsync()
        {
            try
            {
                await DataContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var a = ex.EntityValidationErrors;
                foreach (var dbEntityValidationResult in a)
                {
                    var b = dbEntityValidationResult.ValidationErrors;

                    foreach (var dbValidationError in b)
                    {
                        Debug.WriteLine("\n\n\n\n\n\n\n\n\nErr message: " + dbValidationError.ErrorMessage +
                                        "\n\nErr property: " + dbValidationError.PropertyName + "\n\n\n\n\n\n\n\n\n");
                    }

                }

            }
        }
    }
}
