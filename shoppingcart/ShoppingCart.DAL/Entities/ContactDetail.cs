using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("ContactDetail")]
    public class ContactDetail
    {
        public ContactDetail()
        {
            Telephones = new HashSet<Telephone>();
        }

        public long Id{ get; set; }

        [StringLength(500)]
        public string Name{ get; set; }

        [StringLength(500)]
        public string Discription{ get; set; }

        [StringLength(500)]
        public string Street{ get; set; }

        [StringLength(500)]
        public string ZipCode{ get; set; }

        public virtual Shop Shop{ get; set; }

        public virtual ICollection<Telephone> Telephones{ get; set; }
    }
}
