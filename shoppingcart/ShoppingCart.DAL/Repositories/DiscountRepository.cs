using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IDiscountRepository : IRepository<Discount>
    { }

    public class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
    {
        public DiscountRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
  
}
