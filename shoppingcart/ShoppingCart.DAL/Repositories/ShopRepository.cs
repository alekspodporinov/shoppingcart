using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IShopRepository : IRepository<Shop>
    { }

    public class ShopRepository : RepositoryBase<Shop>, IShopRepository
    {
        public ShopRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
   
}
