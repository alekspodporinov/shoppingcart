using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IStateRepository : IRepository<State>
    { }

    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
}
