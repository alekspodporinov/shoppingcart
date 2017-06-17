using AutoMapper;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.ViewModels;
using ShoppingCart.DAL.Entities;

namespace ShoppingCart.BLL.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
               //Entity to Dto
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<Characteristic, CharacteristicDto>().ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(c => c.CategoryId));
                cfg.CreateMap<Photo, PhotoDto>();
                cfg.CreateMap<Comment, CommentDto>()
                    .ForMember(dest => dest.ApplicationUser,
                        opt => opt.MapFrom(c => new UserDto {Name = c.ApplicationUser.Email}));//TODO:Поправить эту хню
                cfg.CreateMap<Discount, DiscountDto>();
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<CharacteristicValue, CharacteristicValueDto>();
                //Dto to ViewModel
                cfg.CreateMap<Product, ProductCreateViewModel>();
                cfg.CreateMap<Product, ProductListViewModel>();
                cfg.CreateMap<DiscountDto, DiscountViewModel>();
                cfg.CreateMap<Photo, PhotoViewModel>();
                cfg.CreateMap<CommentDto, CommentViewModel>().ForMember(dest => dest.UserFirstNameFrom, opt => opt.MapFrom(c => c.ApplicationUser.Name));
                cfg.CreateMap<CategoryDto, CategoryViewModel>().ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(c => c.ParentCategory.Id));
                cfg.CreateMap<CharacteristicDto, CharacteristicViewModel>();
            });
        }
    }
}
