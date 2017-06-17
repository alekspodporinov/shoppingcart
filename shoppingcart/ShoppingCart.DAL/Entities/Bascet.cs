using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Bascet")]
    public class Bascet
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOrder { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Product Product { get; set; }

        public virtual State State { get; set; }
    }
}
