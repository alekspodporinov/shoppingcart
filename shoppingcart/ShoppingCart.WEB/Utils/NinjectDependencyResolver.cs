//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using Ninject;
//using ShoppingCart.BLL.Interfaces;
//using ShoppingCart.BLL.Services;

//namespace ShoppingCart.WEB.Utils
//{
//    public class NinjectDependencyResolver : IDependencyResolver
//    {
//        private readonly IKernel _kernel;
//        public NinjectDependencyResolver(IKernel kernelParam)
//        {
//            _kernel = kernelParam;
//            AddBindings();
//        }
//        public object GetService(Type serviceType)
//        {
//            return _kernel.TryGet(serviceType);
//        }
//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            try
//            {
//                return _kernel.GetAll(serviceType);
//            }
//            catch (Exception)
//            {
//                return new List<object>();
//            }
//        }
//        private void AddBindings()
//        {
//            _kernel.Bind<IIdentityUserService>().To<IdentityUserService>();
//            _kernel.Bind<ICategoryService>().To<CategoryService>();
            

//        }
//    }
//}