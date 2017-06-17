using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface ITelephoneRepository : IRepository<Telephone>
    { }

    public class TelephoneRepository : RepositoryBase<Telephone>, ITelephoneRepository
    {
        public TelephoneRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
}
