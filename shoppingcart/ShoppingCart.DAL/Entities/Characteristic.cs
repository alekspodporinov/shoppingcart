using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Characteristic")]
    public class Characteristic//+
    {
        public Characteristic()
        {
            Values = new HashSet<CharacteristicValue>();
        }

        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool Filter { get; set; }

        [Required]
        [StringLength(100)]
        public string MetaValue { get; set; }

        [StringLength(100)]
        public string Measure { get; set; }

        public long CategoryId { get; set; }
        [Required]
        public bool Publish { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<CharacteristicValue> Values { get; set; }
    }
}
