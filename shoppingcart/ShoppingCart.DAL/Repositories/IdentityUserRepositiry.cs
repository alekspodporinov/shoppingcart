using System;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCart.DAL.CustomIdentity;
using ShoppingCart.DAL.Infrastructure;

namespace ShoppingCart.DAL.Repositories
{
    public interface IIdentityUserRepository : IDisposable
    {
        CustomUserManager UserManager { get; }
        CustomRoleManager RoleManager { get; }
    }

    public class IdentityUserRepositiry : Disposable, IIdentityUserRepository
    {
        private readonly CustomUserManager _userManager;
        private readonly CustomRoleManager _roleManager;

        public IdentityUserRepositiry(IDatabaseFactory databaseFactory)
        {
            var dataContext = databaseFactory.Get();
            _userManager = CustomUserManager.CreateStatic(dataContext);
            _roleManager = new CustomRoleManager(new RoleStore<CustomRole, long, CustomUserRole>(dataContext));
        }

        public CustomUserManager UserManager => _userManager;

        public CustomRoleManager RoleManager => _roleManager;

        protected override void DisposeObject()
        {
            _userManager.Dispose();
            _roleManager.Dispose();
        }
    }
}
