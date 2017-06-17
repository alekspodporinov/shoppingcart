using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface ICharacteristicValueRepository : IRepository<CharacteristicValue>
    { }

    public class CharacteristicValueRepository : RepositoryBase<CharacteristicValue>, ICharacteristicValueRepository
    {
        public CharacteristicValueRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }
    }
}
