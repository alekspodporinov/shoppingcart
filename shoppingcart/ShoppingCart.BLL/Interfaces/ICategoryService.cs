using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.BLL.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<OperationDetails> Create(CategoryViewModel сategoryViewModel);
        Task<OperationDetails> Update(CategoryViewModel сategoryViewModel);
        Task<OperationDetails> Delete(long id);
        CategoryViewModel GetById(long categoryId);
        IEnumerable<CategoryViewModel> GetAll(long? parentCategoryId);
        Task<bool> CheckCategoryName(long id, string name);
    }
}