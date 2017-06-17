using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ShoppingCart.BLL.ViewModels.Service;

namespace ShoppingCart.WEB.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult SuccessfulAddition(ServiceViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}