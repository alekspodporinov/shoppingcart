using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using AutoMapper;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.ViewModels;
using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;
using ShoppingCart.DAL.Repositories;

namespace ShoppingCart.BLL.Services
{
    //TODO:Допилить удаление
    public class CategoryService : ICategoryService
    {
        readonly IUnitOfWork _dataBase;
        readonly ICategoryRepository _categoryRepository;
        readonly IProductRepository _productRepository;
        readonly ICharacteristicRepository _characteristicRepository;
        readonly ICharacteristicValueRepository _characteristicValueRepository;
        readonly IPhotoRepository _photoRepository;
        readonly IProductService _productService;
        readonly ICharacteristicService _characteristicService;


        public CategoryService(IUnitOfWork dataBaase, ICategoryRepository categoryRepository, IProductRepository productRepository, ICharacteristicRepository characteristicRepository, ICharacteristicValueRepository characteristicValueRepository, IPhotoRepository photoRepository, IProductService productService, ICharacteristicService characteristicService)
        {
            _dataBase = dataBaase;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _characteristicRepository = characteristicRepository;
            _characteristicValueRepository = characteristicValueRepository;
            _photoRepository = photoRepository;
            _productService = productService;
            _characteristicService = characteristicService;
        }

        public void Dispose()
        {
          
        }

        public async Task<bool> CheckCategoryName(long id, string  name)
        {
            if (id != 0)
                return _categoryRepository.GetById(id).Name == name || _categoryRepository.GetAll().All(e => e.Name != name);
            return _categoryRepository.GetAll().All(e => e.Name != name);
        }

        public async Task<OperationDetails> Create(CategoryViewModel сategoryViewModel)
        {
            try
            {
                if (_categoryRepository.GetAll().Any(e => e.Name == сategoryViewModel.Name))
                    throw new ArgumentException("Такое имя уже есть", nameof(сategoryViewModel.Name));

                _categoryRepository.Add(new Category
                {
                    Name = сategoryViewModel.Name,
                    ParentCategory =
                        сategoryViewModel.ParentCategoryId == null
                            ? null
                            : _categoryRepository.GetById(сategoryViewModel.ParentCategoryId.Value),
                    Discription = сategoryViewModel.Discription,
                    Publish = сategoryViewModel.Publish
                });

                await _dataBase.SaveAsync();

                return new OperationDetails(true, "Категория успешно добавлена", "");
            }
            catch (Exception ex)
            {              
                return new OperationDetails(false, "Что то пошло не так:\n\n", ex.Message);
            }
        
        }

        public async Task<OperationDetails> Update(CategoryViewModel сategoryViewModel)
        {
            try
            {
                var category = _categoryRepository.GetById(сategoryViewModel.Id);
                if (category == null)
                    throw new NullReferenceException("Что то пошло не так, категория не найдена");

                category.Name = сategoryViewModel.Name;
                category.Discription = сategoryViewModel.Discription;
                category.Publish = сategoryViewModel.Publish;
                _categoryRepository.Update(category);

                await _dataBase.SaveAsync();
                return new OperationDetails(true, "Категория успешно добавлена", "");
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "category");
            }

        }

        private async Task DeleteA(Category delCategiry)
        {
            while (delCategiry.Characteristics.Count != 0)
            {
                await _characteristicService.Delete(delCategiry.Characteristics.Last().Id);
            }


            //foreach (var characteristic in delCategiry.Characteristics)
            //{
                
            //}
            while(delCategiry.Products.Count != 0)
            {
                await _productService.Delete(delCategiry.Products.Last().Id);
            }
            //foreach (var product in delCategiry.Products)
            //{
            //    await _productService.Delete(product.Id);
            //}
        }

        public async Task<OperationDetails> Delete(long id)
        {
            var delCategiry = _categoryRepository.GetById(id);
            if(delCategiry == null)
                return new OperationDetails(false, "Категория не найдена", "delCategiry");



            while (delCategiry.Children.Count != 0)
            {
                await Delete(delCategiry.Children.Last().Id);
            }

            //for (var i = 0; i < delCategiry.Children.Count; i++)
            //{
            //    var dcat = delCategiry.Children.ToList()[i];
            //    await Delete(dcat.Id);
            //}

            //foreach (var category in delCategiry.Children)
            //{
            //    await Delete(category.Id);
            //}
             
            await DeleteA(delCategiry);
            _categoryRepository.Delete(delCategiry);

            await _dataBase.SaveAsync();

            return new OperationDetails(true, "Категория успешно добавлена", "");
        }

        public CategoryViewModel GetById(long categoryId)
        {
            return Mapper.Map<CategoryDto, CategoryViewModel>(Mapper.Map<Category, CategoryDto>(_categoryRepository.GetById(categoryId)));
        }

        public IEnumerable<CategoryViewModel> GetAll(long? parentCategoryId)
        {
            return _categoryRepository
                .GetAll().Where(e => e.ParentId == parentCategoryId)
                .Select(Mapper.Map<Category, CategoryDto>).Select(Mapper.Map<CategoryDto, CategoryViewModel>);
        }
    }
}
