using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("CharacteristicValue")]
    public class CharacteristicValue//+
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Value { get; set; }

        public long ProductId { get; set; }

        public long CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; }

        public virtual Product Product { get; set; }
    }
}