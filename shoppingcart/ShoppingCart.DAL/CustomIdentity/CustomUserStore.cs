using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCart.DAL.EF;
using ShoppingCart.DAL.Entities;

namespace ShoppingCart.DAL.CustomIdentity
{
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
