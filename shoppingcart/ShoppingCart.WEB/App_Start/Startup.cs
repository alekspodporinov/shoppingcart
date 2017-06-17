using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ShoppingCart.WEB;

[assembly: OwinStartup(typeof(Startup))]

namespace ShoppingCart.WEB
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
               
            });
        }
    }
}
//TODO:Список Дел:
//TODO:Сделать опопвещение о результате добавлении/удалении/изменении объекта