using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.BLL.ViewModels
{
    public class PhotoViewModel
    {
        public long Id { get; set; }
        public HttpPostedFileBase OriginalPhoto { get; set; }
        public string AspectRatio { get; set; }
    }
}
