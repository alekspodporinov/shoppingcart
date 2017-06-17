using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Photoes")]
    public class Photo
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        [StringLength(500)]
        public string UrlBigPhoto { get; set; }

        [StringLength(500)]
        public string UrlSmallPhoto { get; set; }

        [StringLength(500)]
        public string UrlMediumPhoto { get; set; }

        [StringLength(5)]
        public string AspectRatio { get; set; }

        public virtual Product Product { get; set; }
    }
}
