using System;
using ShoppingCart.DAL.Entities;

namespace ShoppingCart.BLL.DTO
{
    public class CharacteristicDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Filter { get; set; }
        public long ParentCategoryId { get; set; }
        public string MetaValue { get; set; }
        public string Measure { get; set; }
        public bool Publish { get; set; }

    }
}