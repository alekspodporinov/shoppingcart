using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{

    [Table("Shop")]
    public class Shop
    {
        public Shop()
        {
            ContactDetails = new HashSet<ContactDetail>();
            Logoes = new HashSet<Logo>();
        }

        public long Id { get; set; }

        [StringLength(500)]
        public string Name{ get; set; }

        [StringLength(500)]
        public string Discription{ get; set; }

        public virtual ICollection<ContactDetail> ContactDetails{ get; set; }

        public virtual ICollection<Logo> Logoes{ get; set; }
    }
}
