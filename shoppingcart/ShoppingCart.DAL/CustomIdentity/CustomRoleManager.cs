using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShoppingCart.DAL.CustomIdentity
{
    public class CustomRoleManager : RoleManager<CustomRole, long>
    {
        public CustomRoleManager(RoleStore<CustomRole, long, CustomUserRole> store)
            : base(store)
        { }
    }
}
