using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.BLL.Interfaces
{
    public interface IProductService
    {
        Task<OperationDetails> Create(ProductCreateViewModel productViewModel, List<PhotoViewModel> photoes, List<CharacteristicValueViewModel> characteristicValue);
        Task<OperationDetails> Update(ProductUpdateViewModel productViewModel);
        Task<OperationDetails> Delete(long productId);
        ProductUpdateViewModel GetById(long productId, long parentCategoryId);
        ProductCreateViewModel GetByIdForUpdate(long productId, long parentCategoryId);
        IEnumerable<ProductListViewModel> GetAll(long parentCategoryId);
        IEnumerable<CharacteristicValueViewModel> GetAllCharacteristic(long parentCategoryId);
        IEnumerable<CharacteristicValueViewModel> GetCharacteristicForProduct(long productId, long parentCategoryId);
        IEnumerable<PhotoProductViewModel> GetPhotoForProduct(long productId);
    }
}

