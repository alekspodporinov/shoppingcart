using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    
    [Table("State")]
    public class State
    {
        public State()
        {
            Bascets = new HashSet<Bascet>();
        }

        public long Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public virtual ICollection<Bascet> Bascets { get; set; }
    }
}
