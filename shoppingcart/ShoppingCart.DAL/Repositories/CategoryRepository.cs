using System.Data.Entity;
using System.Threading.Tasks;
using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> FindByNameAsync(string name);
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
       public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }

        public async Task<Category> FindByNameAsync(string name)
        {
           return await Dbset.FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
