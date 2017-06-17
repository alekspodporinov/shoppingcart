using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    { }

    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
}
