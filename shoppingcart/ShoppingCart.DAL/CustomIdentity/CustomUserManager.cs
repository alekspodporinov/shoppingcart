using Microsoft.AspNet.Identity;
using ShoppingCart.DAL.EF;
using ShoppingCart.DAL.Entities;

namespace ShoppingCart.DAL.CustomIdentity
{
    public class CustomUserManager : UserManager<ApplicationUser, long>
    {
        public CustomUserManager(IUserStore<ApplicationUser, long> store)
            : base(store)
        {
        }

        public static CustomUserManager CreateStatic(ApplicationDbContext context)
        {
            CustomUserManager manager = new CustomUserManager(new CustomUserStore(context));

            manager.UserValidator = new UserValidator<ApplicationUser, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
            };

            return manager;
        }
    }
}
