using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Logo")]
    public class Logo
    {
        public long Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string PictureUrl { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
