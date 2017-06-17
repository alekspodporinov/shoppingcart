using Microsoft.AspNet.Identity.EntityFramework;

namespace ShoppingCart.DAL.CustomIdentity
{
    public class CustomRole : IdentityRole<long, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
