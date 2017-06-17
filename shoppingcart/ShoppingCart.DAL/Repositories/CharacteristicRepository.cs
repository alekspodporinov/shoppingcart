using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface ICharacteristicRepository : IRepository<Characteristic>
    { }

    public class CharacteristicRepository : RepositoryBase<Characteristic>, ICharacteristicRepository
    {
        public CharacteristicRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
  
}
