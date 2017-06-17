using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface ILogoRepository : IRepository<Logo>
    { }

    public class LogoRepository : RepositoryBase<Logo>, ILogoRepository
    {
        public LogoRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }

}
