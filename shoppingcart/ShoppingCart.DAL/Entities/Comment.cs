using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Comment")]
    public class Comment//+
    {
        public long Id { get; set; }

        [StringLength(500)]
        public string CommentBody { get; set; }

        public long ProductId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateComment { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Product Product { get; set; }
    }
}
