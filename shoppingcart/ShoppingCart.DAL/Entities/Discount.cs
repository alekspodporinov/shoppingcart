using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Discount")]
    public class Discount//+
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        [StringLength(500)]
        public string Disctiption { get; set; }

        public long? SalePercent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Required]
        public bool Publish { get; set; }

        public virtual Product Product { get; set; }
    }
}
