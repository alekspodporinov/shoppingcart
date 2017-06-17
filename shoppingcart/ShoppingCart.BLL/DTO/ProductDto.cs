using System;
using System.Collections.Generic;
using ShoppingCart.DAL.Entities;

namespace ShoppingCart.BLL.DTO
{
    public class ProductDto
    {
        public ProductDto()
        {
            Comments = new HashSet<CommentDto>();
            Discounts = new HashSet<DiscountDto>();
            Photoes = new HashSet<PhotoDto>();
            CharacteristicValue = new HashSet<CharacteristicValueDto>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public bool Publish { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
        public virtual ICollection<CategoryDto> Categories { get; set; }
        public virtual ICollection<DiscountDto> Discounts { get; set; }
        public virtual ICollection<PhotoDto> Photoes { get; set; }
        public virtual ICollection<CharacteristicValueDto> CharacteristicValue { get; set; }
    }
}
