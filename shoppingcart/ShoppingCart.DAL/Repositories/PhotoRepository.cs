using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IPhotoRepository : IRepository<Photo>
    { }

    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
}
