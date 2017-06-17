using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.ViewModels
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string CommentBody { get; set; }
        public DateTime? DateComment { get; set; }
        public string UserFirstNameFrom { get; set; }
        public string UserLastNameFrom { get; set; }
    }

}
