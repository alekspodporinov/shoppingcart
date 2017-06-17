using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using ImageResizer;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.ViewModels;
using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;
using ShoppingCart.DAL.Repositories;

namespace ShoppingCart.BLL.Services
{
    public class ProductService : IProductService
    {
        readonly IUnitOfWork _dataBase;
        readonly IProductRepository _productRepository;
        readonly ICategoryRepository _categoryRepository;
        readonly ICharacteristicValueRepository _characteristicValueRepository;
        readonly ICharacteristicRepository _characteristicRepository;
        readonly IPhotoRepository _photoRepository;

        public ProductService(IUnitOfWork dataBase, IProductRepository productRepository, ICategoryRepository categoryRepository, ICharacteristicValueRepository characteristicValueRepository, ICharacteristicRepository characteristicRepository, IPhotoRepository photoRepository)
        {
            _dataBase = dataBase;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _characteristicValueRepository = characteristicValueRepository;
            _characteristicRepository = characteristicRepository;
            _photoRepository = photoRepository;
        }

        private List<Category> GetCategoryForProduct(long parentCategoryId)
        {

            var cat = _categoryRepository.GetById(parentCategoryId);

            var listCat = new List<Category>();

            listCat.Add(cat);

            if (cat.ParentCategory != null)
                listCat.AddRange(GetCategoryForProduct(cat.ParentCategory.Id));

            return listCat;
        }

        private void UpdateCharacteristicValue(IList<CharacteristicValueViewModel> listValue, long productId)
        {
            foreach (var charVal in listValue)
            {
                var characteristic = _characteristicRepository.GetById(charVal.CharacteristicId);
                var value = new CharacteristicValue
                {
                    CharacteristicId = characteristic.Id,
                    ProductId = productId,
                    Value = charVal.Value,
                };
                _characteristicValueRepository.Add(value);
            }
        }

        private void AddCharacteristicValueToDb(IList<CharacteristicValueViewModel> listValue, long productId)
        {
            foreach (var charVal in listValue)
            {
                var characteristic = _characteristicRepository.GetById(charVal.CharacteristicId);
                var value = new CharacteristicValue
                {
                    CharacteristicId = characteristic.Id,
                    ProductId = productId,
                    Value = string.IsNullOrEmpty(charVal.Value) ? "-" : charVal.Value,
            };
                _characteristicValueRepository.Add(value);
            }
        }

        private void DeletePhotoes(List<long> listDelPhotoesId)
        {

            foreach (var delPhotoId in listDelPhotoesId)
            {
                var deletePhoto = _photoRepository.GetById(delPhotoId);
                File.Delete(deletePhoto.UrlBigPhoto);
                File.Delete(deletePhoto.UrlMediumPhoto);
                File.Delete(deletePhoto.UrlSmallPhoto);
                _photoRepository.Delete(e => e.Id == delPhotoId);
            }
        }

        private void AddPhotoToDb(List<PhotoViewModel> photoes, long newProductId)
        {
            
            var path = HttpContext.Current.Server.MapPath("~/Files/");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var photoViewModel in photoes)
            {
               
                // получаем расширение
                var ext = photoViewModel.OriginalPhoto.FileName.Substring(photoViewModel.OriginalPhoto.FileName.LastIndexOf(".") + 1);

                // создаем инструкции для различных версий
                var versions = new Dictionary<string, string>();
                versions.Add("_small", "maxwidth=200&maxheight=200&format=" + ext);
                versions.Add("_medium", "maxwidth=400&maxheight=400&format=" + ext);
                versions.Add("_large", "maxwidth=600&maxheight=600&format=" + ext);

                var photo = new Photo
                {
                    ProductId = newProductId,
                    AspectRatio = photoViewModel.AspectRatio
                };

                foreach (var suffix in versions.Keys)
                {

                    photoViewModel.OriginalPhoto.InputStream.Seek(0, System.IO.SeekOrigin.Begin);

                    var res = ImageBuilder.Current.Build(
                        new ImageJob(
                            photoViewModel.OriginalPhoto.InputStream,
                            path + photoViewModel.OriginalPhoto.FileName.Remove(photoViewModel.OriginalPhoto.FileName.LastIndexOf(".")) + suffix,
                            new Instructions(versions[suffix]),
                            false,
                            true));

                    switch (suffix)
                    {
                        case "_small":
                            photo.UrlSmallPhoto = res.FinalPath;
                            break;
                        case "_medium":
                            photo.UrlMediumPhoto = res.FinalPath;
                            break;
                        case "_large":
                            photo.UrlBigPhoto = res.FinalPath;
                            break;
                    }
                }
                _photoRepository.Add(photo);

            }
        }

        public async Task<OperationDetails> Create(ProductCreateViewModel productViewModel, List<PhotoViewModel> photoes, List<CharacteristicValueViewModel> characteristicValue)
       {
            var newProduct = new Product
            {
                Model = productViewModel.Model,
                Code = productViewModel.Code,
                Discription = productViewModel.Discription,
                Manufacturer = productViewModel.Manufacturer,
                Price = productViewModel.Price,
                SerialNumber = productViewModel.SerialNumber,
                Title = productViewModel.Title,
                Categories = GetCategoryForProduct(productViewModel.ParentCategoryId),
                Publish = productViewModel.Publish
            };


            _productRepository.Add(newProduct);
            AddCharacteristicValueToDb(characteristicValue, newProduct.Id);
            AddPhotoToDb(photoes, newProduct.Id);

           await _dataBase.SaveAsync();
           
            return new OperationDetails(false, "Категория с таким название уже существует", "Name");
        }

        public async Task<OperationDetails> Update(ProductUpdateViewModel productViewModel)
        {
            var newProduct = _productRepository.GetById(productViewModel.EditProduct.Id);
            if (newProduct == null)
                return new OperationDetails(false, "Что то пошло не так, не найден Id товара", "Id");

            newProduct.Model =          productViewModel.EditProduct.Model;
            newProduct.Code =           productViewModel.EditProduct.Code;
            newProduct.Discription =    productViewModel.EditProduct.Discription;
            newProduct.Manufacturer =   productViewModel.EditProduct.Manufacturer;
            newProduct.Price =          productViewModel.EditProduct.Price;
            newProduct.SerialNumber =   productViewModel.EditProduct.SerialNumber;
            newProduct.Title =          productViewModel.EditProduct.Title;
            newProduct.Publish = productViewModel.EditProduct.Publish;

            var photoes =
               _productRepository.GetById(productViewModel.EditProduct.Id)
                   .Photoes.Select(e => e.Id)
                   .ToList()
                   .Except(productViewModel.OldPhotoes.Select(e => e.Id)).ToList();

            foreach (var delphoto in photoes)
            {
                newProduct.Photoes.Remove(_photoRepository.GetById(delphoto));
            }


            //TODO:Пофиксить сохранение на каждой итерации!!!

            _productRepository.Update(newProduct);
            DeletePhotoes(photoes);
            await _dataBase.SaveAsync();
            var charValue = productViewModel.Characteristics;

            foreach (var item in charValue)
            {
                var charVal = _characteristicValueRepository.GetById(item.Id);

                if (charVal != null)
                {

                    charVal.CharacteristicId = item.CharacteristicId;
                    charVal.ProductId = productViewModel.EditProduct.Id;
                    charVal.Value = string.IsNullOrEmpty(item.Value) ? "-" : item.Value;
                    _characteristicValueRepository.Update(charVal);

                    await _dataBase.SaveAsync();
                }
                else
                {
                    var characteristic = _characteristicRepository.GetById(item.CharacteristicId);
                    var value = new CharacteristicValue
                    {
                        CharacteristicId = characteristic.Id,
                        ProductId = productViewModel.EditProduct.Id,
                        Value = string.IsNullOrEmpty(item.Value) ? "-" : item.Value,
                };

                    _characteristicValueRepository.Add(value);
                    await _dataBase.SaveAsync();
                }
            };

           
            AddPhotoToDb(productViewModel.NewPhotoes, newProduct.Id);


            await _dataBase.SaveAsync();

            return new OperationDetails(true, "Все исправлено", "Name");
        }

        public async Task<OperationDetails> Delete(long productId)
        {
            var delProduct = _productRepository.GetById(productId);
            if(delProduct == null)
                return new OperationDetails(false, "Что то пошло не так, не найден Id товара", "Id");

            _characteristicValueRepository.Delete(e => e.ProductId == delProduct.Id);
            _photoRepository.Delete(e => e.ProductId == delProduct.Id);
            _productRepository.Delete(delProduct);

            await _dataBase.SaveAsync();
            return new OperationDetails(false, "Категория с таким название уже существует", "Name");
        }

        public IEnumerable<CharacteristicValueViewModel> GetCharacteristicForProduct(long productId, long parentCategoryId)
        {

            var characteristics = _productRepository.GetById(productId).Categories.SelectMany(e => e.Characteristics);

           // var characteristics = _characteristicRepository.GetAll().Where(e => e.CategoryId == categories.Select(c => c.));

            var characteristicsValue = _characteristicValueRepository.GetAll()
                .Where(e => e.ProductId == productId).ToList();

            var characteristicValueViewModels = new List<CharacteristicValueViewModel>();

            foreach (var characteristic in characteristics)
            {

                var characteristicVal = new CharacteristicValueViewModel
                {
                    Measure = characteristic.Measure,
                    CharacteristicId = characteristic.Id,
                    Name = characteristic.Name
                };

                foreach (var characteristicValue in characteristicsValue)
                {
                    if (characteristicValue.CharacteristicId != characteristic.Id) continue;
                    characteristicVal.Value = characteristicValue.Value;
                    characteristicVal.Id = characteristicValue.Id;
                    break;
                }

                characteristicValueViewModels.Add(characteristicVal);
            }



            //(from characteristic in characteristics
            //                                     from characteristicValue in characteristicsValue
            //                                     where characteristic.Id == characteristicValue.CharacteristicId
            //                                     select
            //                                         new CharacteristicValueViewModel
            //                                         {
            //                                             Name = characteristic.Name,
            //                                             CharacteristicId = characteristic.Id,
            //                                             Id = characteristicValue.Id,
            //                                             Value = characteristicValue.Value,
            //                                             Measure = characteristicValue.Characteristic.Measure
            //                                         }).ToList();


            return characteristicValueViewModels;
        }

    
        public ProductCreateViewModel GetByIdForUpdate(long productId, long parentCategoryId)
        {

            var product = _productRepository.GetById(productId);
            var viewModel = Mapper.Map<Product, ProductCreateViewModel>(product);

            if (viewModel == null)
                return null;

            viewModel.ParentCategoryId = parentCategoryId;

            return viewModel;
        }

        public IEnumerable<PhotoProductViewModel> GetPhotoForProduct(long productId)
        {
            var photoes = _productRepository.GetById(productId).Photoes;

            var photoesViewModel = photoes.Select(photo => new PhotoProductViewModel
            {
                Id = photo.Id,
                UrlFotoNormal = photo.UrlSmallPhoto,
                AspectRatio = photo.AspectRatio,
                Name = new FileInfo(photo.UrlSmallPhoto).Name,
                Size = new FileInfo(photo.UrlSmallPhoto).Length.ToString()
            });

            return photoesViewModel;
        }

        //TODO:Постараться убрать "long parentCategoryId"
        public ProductUpdateViewModel GetById(long productId, long parentCategoryId)
        {

            //TODO:И ЕЩЕ С ЭТИМ РАЗОБРАТЬСЯ НУЖНО
            var product = _productRepository.GetById(productId);

            var characteristics = _characteristicRepository.GetAll();

            var characteristicsValue = _characteristicValueRepository.GetAll()
                .Where(e => e.ProductId == product.Id).ToList();

            var characteristicValueViewModels = (from characteristic in characteristics
                                                 from characteristicValue in characteristicsValue
                                                 where characteristic.Id == characteristicValue.CharacteristicId
                                                 select
                                                     new CharacteristicValueViewModel
                                                     {
                                                         Name = characteristic.Name,
                                                         CharacteristicId = characteristic.Id,
                                                         Id = characteristicValue.Id,
                                                         Value = characteristicValue.Value,
                                                         Measure = characteristicValue.Characteristic.Measure
                                                     }).ToList();

            var viewModel = Mapper.Map<Product, ProductUpdateViewModel>(product);
            //TODO:Аж где то до сюда

            if (viewModel == null)
                return null;

          //  viewModel.ParentCategoryId = parentCategoryId;
            viewModel.Characteristics = characteristicValueViewModels;
            return viewModel;
        }

        public IEnumerable<ProductListViewModel> GetAll(long parentCategoryId)
        {
            var s = _productRepository.GetAll().Where(e => e.Categories.Any(c => c.Id == parentCategoryId)).Select(Mapper.Map<Product, ProductListViewModel>).ToList();
            return s;

        }

        public IEnumerable<CharacteristicValueViewModel> GetAllCharacteristic(long parentCategoryId)
        {
            var category = _categoryRepository.GetById(parentCategoryId);
           
            List<CharacteristicValueViewModel> model = category.Characteristics.Select(item => new CharacteristicValueViewModel
            {
                CharacteristicId = item.Id,Name = item.Name, Measure = item.Measure
            }).ToList();

            if (category.ParentCategory != null)
                model.AddRange(GetAllCharacteristic(category.ParentCategory.Id));

            return model;
        }
    }
}
