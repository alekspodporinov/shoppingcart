using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IBascetRepository : IRepository<Bascet>
    { }

    public class BascetRepository : RepositoryBase<Bascet>, IBascetRepository
    {
        public BascetRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }
    }
    
}

