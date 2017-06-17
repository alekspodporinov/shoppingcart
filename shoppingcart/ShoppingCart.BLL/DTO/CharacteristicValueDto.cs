using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.DTO
{
    public class CharacteristicValueDto
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public string MetaValue { get; set; }

        public string Measure { get; set; }

        public long ProductId { get; set; }

        public bool Publish { get; set; }

        public long CharacteristicId { get; set; }
    }
}
