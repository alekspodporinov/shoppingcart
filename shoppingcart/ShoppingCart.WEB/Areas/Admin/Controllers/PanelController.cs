using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.WEB.CustomAttrinutes;

namespace ShoppingCart.WEB.Areas.Admin.Controllers
{
    [CustomAuthorization(Url = "/Account/LoginAdmin")]
    public class PanelController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}