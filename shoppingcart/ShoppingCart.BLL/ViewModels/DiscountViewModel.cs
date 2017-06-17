using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.ViewModels
{
    public class DiscountViewModel
    {
        [Required]
        public bool Publish { get; set; }
        public long Id { get; set; }

        public string Disctiption { get; set; }

        public long? SalePercent { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
