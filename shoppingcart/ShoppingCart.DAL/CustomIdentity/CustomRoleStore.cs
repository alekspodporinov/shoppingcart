using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCart.DAL.EF;

namespace ShoppingCart.DAL.CustomIdentity
{
    public class CustomRoleStore : RoleStore<CustomRole, long, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        { }
    }
}
