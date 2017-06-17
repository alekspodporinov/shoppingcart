using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public long Id { get; set; }

        public string Name{ get; set; }

        public string SurnameName { get; set; }
        public string Address{ get; set; }

        public virtual ApplicationUser ApplicationUser{ get; set; }
    }
}
