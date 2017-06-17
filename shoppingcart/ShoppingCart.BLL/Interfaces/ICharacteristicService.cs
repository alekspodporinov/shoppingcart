using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.BLL.Interfaces
{
    public interface ICharacteristicService
    {
        Task<OperationDetails> Create(CharacteristicViewModel characteristicViewModel);
        Task<OperationDetails> Update(CharacteristicViewModel characteristicViewModel);
        Task<OperationDetails> Delete(long characteristicId);
        CharacteristicViewModel GetById(long characteristicId);
        IEnumerable<CharacteristicViewModel> GetAll(long parentCategoryId);
        bool CheckCharacteristicName(string name, long id);
    }
}
