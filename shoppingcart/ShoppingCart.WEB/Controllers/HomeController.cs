using System.Web.Mvc;
using ShoppingCart.BLL.Interfaces;

namespace ShoppingCart.WEB.Controllers
{
    public class HomeController : Controller
    {
        IIdentityUserService UserService;

        public HomeController(IIdentityUserService userService)
        {
            UserService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}