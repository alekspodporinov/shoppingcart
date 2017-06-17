using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.ViewModels
{
    public class CategoryDeleteViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CountChildCategory { get; set; }
        public int CountAllProductInCategory { get; set; }
    }
}
