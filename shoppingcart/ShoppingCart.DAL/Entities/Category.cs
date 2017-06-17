using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Category")]
    public class Category//+
    {
        public Category()
        {
            Children = new HashSet<Category>();
            Characteristics = new HashSet<Characteristic>();
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }

        public long? ParentId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public bool Publish { get; set; }
        [StringLength(500)]
        public string Discription { get; set; }
        public virtual ICollection<Category> Children { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
