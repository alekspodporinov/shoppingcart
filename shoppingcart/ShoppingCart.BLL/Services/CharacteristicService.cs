using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CharacteristicService : ICharacteristicService
    {
        readonly IUnitOfWork _dataBase;
        readonly ICharacteristicRepository _characteristicRepository;
        readonly ICategoryRepository _categoryRepository;
        readonly IProductRepository _productRepository;
        readonly ICharacteristicValueRepository _characteristicValueRepository;
        public CharacteristicService(IUnitOfWork dataBase, ICharacteristicRepository characteristicRepository, ICategoryRepository categoryRepository, IProductRepository productRepository, ICharacteristicValueRepository characteristicValueRepository)
        {
            _dataBase = dataBase;
            _characteristicRepository = characteristicRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _characteristicValueRepository = characteristicValueRepository;
        }

        public bool CheckCharacteristicName(string name, long id)
        {
            if(id != 0)
                return _characteristicRepository.GetById(id).Name == name || _characteristicRepository.GetAll().All(e => e.Name != name);

            return _characteristicRepository.GetAll().All(e => e.Name != name);
        }

        public async Task<OperationDetails> Create(CharacteristicViewModel characteristicViewModel)
        {
            try
            {
                _characteristicRepository.Add(new Characteristic
                {
                    Filter = characteristicViewModel.Filter,
                    Name = characteristicViewModel.Name,
                    CategoryId = characteristicViewModel.ParentCategoryId,
                    Measure = characteristicViewModel.Measure,
                    MetaValue = characteristicViewModel.MetaValue,
                    Publish = characteristicViewModel.Publish
                });

                await _dataBase.SaveAsync();

                return new OperationDetails(true, "Категория успешно добавлена", "");
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, "Что то пошло не так:\n\n", ex.Message);
            }
        }

        public async Task<OperationDetails> Update(CharacteristicViewModel characteristicViewModel)
        {
            try
            {
                var сharacteristic = _characteristicRepository.GetById(characteristicViewModel.Id);

                if (сharacteristic == null)
                    throw new NullReferenceException("Что то пошло не так, категория не найдена");

                сharacteristic.Filter = characteristicViewModel.Filter;
                сharacteristic.Name = characteristicViewModel.Name;
                сharacteristic.CategoryId = characteristicViewModel.ParentCategoryId;
                сharacteristic.Measure = characteristicViewModel.Measure;
                сharacteristic.MetaValue = characteristicViewModel.MetaValue;
                сharacteristic.Publish = characteristicViewModel.Publish;

                _characteristicRepository.Update(сharacteristic);

                await _dataBase.SaveAsync();

                return new OperationDetails(true, "Категория успешно обновлена", "");
            }
            catch (Exception ex)
            {
                return new OperationDetails(false, ex.Message, "сharacteristic");
            }
        }

        public async Task<OperationDetails> Delete(long characteristicId)
        {
            var a = _characteristicRepository.GetById(characteristicId);
            var pr = _productRepository.GetAll();

                _characteristicValueRepository.Delete(e => e.CharacteristicId == characteristicId);   
            _characteristicRepository.Delete(a);
            await _dataBase.SaveAsync();
            return new OperationDetails(true, "Категория успешно обновлена", "");
        }

        public CharacteristicViewModel GetById(long characteristicId)
        {
            return
                Mapper.Map<CharacteristicDto, CharacteristicViewModel>(
                    Mapper.Map<Characteristic, CharacteristicDto>(_characteristicRepository.GetById(characteristicId)));
        }

        public IEnumerable<CharacteristicViewModel> GetAll(long parentCategoryId)
        {
            return _characteristicRepository.
                GetAll().
                Where(e => e.Category.Id == parentCategoryId).
                Select(Mapper.Map<Characteristic, CharacteristicDto>).
                Select(Mapper.Map<CharacteristicDto, CharacteristicViewModel>);
        }
    }
}
