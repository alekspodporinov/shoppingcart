using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    [Table("Product")]
    public class Product//+
    {
        public Product()
        {
            Bascets = new HashSet<Bascet>();
            Comments = new HashSet<Comment>();
            Discounts = new HashSet<Discount>();
            Photoes = new HashSet<Photo>();
            CharacteristicValue = new HashSet<CharacteristicValue>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Discription { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(100)]
        public string SerialNumber { get; set; }


        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        public bool Publish { get; set; }

        public virtual ICollection<Bascet> Bascets { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }

        public virtual ICollection<Photo> Photoes { get; set; }

        public virtual ICollection<CharacteristicValue> CharacteristicValue { get; set; }
    }
}
