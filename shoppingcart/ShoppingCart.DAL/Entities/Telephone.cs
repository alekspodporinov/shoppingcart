using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Telephone")]
    public class Telephone
    {
        public long Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Discription { get; set; }

        [StringLength(500)]
        public string Number { get; set; }

        public long ContactDetailsId { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }
    }
}
