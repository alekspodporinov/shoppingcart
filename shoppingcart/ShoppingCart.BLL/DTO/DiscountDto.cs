using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.DTO
{
    public class DiscountDto
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public string Disctiption { get; set; }

        public long? SalePercent { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}
