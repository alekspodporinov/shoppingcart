using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IContactDetailRepository : IRepository<ContactDetail>
    { }

    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
  
}
