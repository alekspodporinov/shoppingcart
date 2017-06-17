using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    { }

    public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(IDatabaseFactory database):base(database)
        { }
    }
}
