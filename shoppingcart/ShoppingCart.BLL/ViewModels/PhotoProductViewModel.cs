using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.ViewModels
{
    public class PhotoProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string UrlFotoNormal { get; set; }
        public string AspectRatio { get; set; }
    }
}
