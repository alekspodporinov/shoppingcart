using Ninject.Modules;
using ShoppingCart.DAL.Infrastructure;
using ShoppingCart.DAL.Repositories;

namespace ShoppingCart.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IDatabaseFactory>().To<DatabaseFactory>().InSingletonScope().WithConstructorArgument(_connectionString);
            Bind<IUnitOfWork>().To<UnitOfWork>();
            LoadRepositories();
        }

        private void LoadRepositories()
        {
            Bind<IBascetRepository>().To<BascetRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ICharacteristicRepository>().To<CharacteristicRepository>();
            Bind<ICharacteristicValueRepository>().To<CharacteristicValueRepository>();
            Bind<ICommentRepository>().To<CommentRepository>();
            Bind<IContactDetailRepository>().To<ContactDetailRepository>();
            Bind<IDiscountRepository>().To<DiscountRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ILogoRepository>().To<LogoRepository>();
            Bind<IPhotoRepository>().To<PhotoRepository>();
            Bind<IShopRepository>().To<ShopRepository>();
            Bind<IStateRepository>().To<StateRepository>();
            Bind<ITelephoneRepository>().To<TelephoneRepository>();
            Bind<IUserProfileRepository>().To<UserProfileRepository>();
            Bind<IIdentityUserRepository>().To<IdentityUserRepositiry>();
        }
    }
}
