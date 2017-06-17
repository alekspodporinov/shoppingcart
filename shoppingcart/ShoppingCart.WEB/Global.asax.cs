using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.ViewModels;
using ShoppingCart.WEB.Binders;
using ShoppingCart.WEB.Controllers;
//using ShoppingCart.WEB.Utils;

namespace ShoppingCart.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(List<PhotoProductViewModel>), new ListOfPhotoesModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
            AutoMapperConfig.RegisterMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

        //private void RegisterDependencyResolver()
        //{
        //    var kernel = new StandardKernel();

        //    // you may need to configure your container here?
        //    RegisterServices(kernel);

        //    DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        //}
    }
}
