using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IProductRepository : IRepository<Product>
    { }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }

}
