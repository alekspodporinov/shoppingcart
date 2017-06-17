using System.Web.Routing;

namespace ShoppingCart.BLL.ViewModels.Service
{
    public class ServiceViewModel
    {
        public string Message { get; set; }
        public string TextLnk { get; set; }
        public string RedirectController { get; set; }
        public string RedirectAction { get; set; }
        public string Area { get; set; }
        public object Values { get; set; }
    }
}