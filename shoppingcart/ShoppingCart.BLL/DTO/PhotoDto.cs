using ShoppingCart.DAL.Entities;

namespace ShoppingCart.BLL.DTO
{
    public class PhotoDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string UrlFotoBig { get; set; }
        public string UrlFotoSmall { get; set; }
        public string UrlFotoNormal { get; set; }
    }
}
