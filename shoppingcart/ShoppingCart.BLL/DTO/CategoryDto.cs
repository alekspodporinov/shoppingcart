using System.Collections.Generic;

namespace ShoppingCart.BLL.DTO
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            Characteristics = new HashSet<CharacteristicDto>();
            Products = new HashSet<ProductDto>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool Publish { get; set; }
        public string Discription { get; set; }
        public ICollection<CharacteristicDto> Characteristics { get; set; }
        public CategoryDto ParentCategory { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}