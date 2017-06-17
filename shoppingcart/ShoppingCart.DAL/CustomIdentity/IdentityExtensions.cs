using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ShoppingCart.DAL.Entities;

namespace ShoppingCart.DAL.CustomIdentity
{
    public static class IdentityExtensions
    {
        public static async Task<ApplicationUser> FindByNameOrEmailAsync
            (this CustomUserManager userManager, string usernameOrEmail, string password)
        {
            var username = usernameOrEmail;
            if (usernameOrEmail.Contains("@"))
            {
                var userForEmail = await userManager.FindByEmailAsync(usernameOrEmail);
                if (userForEmail != null)
                {
                    username = userForEmail.UserName;
                }
            }
            return await userManager.FindAsync(username, password);
        }

        public static ApplicationUser FindByNameOrEmail
           (this CustomUserManager userManager, string usernameOrEmail, string password)
        {
            ApplicationUser a = new ApplicationUser();
            
            var username = usernameOrEmail;
            if (usernameOrEmail.Contains("@"))
            {
                var userForEmail = userManager.FindByEmail(usernameOrEmail);
                if (userForEmail != null)
                {
                    username = userForEmail.UserName;
                }
            }
            return userManager.Find(username, password);
        }

        [DebuggerStepThrough]
        public static int GetUserIdInt(this IIdentity user)
        {
            return Convert.ToInt32(user.GetUserId());
        }
    }
}
