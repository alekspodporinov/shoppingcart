using System;

namespace ShoppingCart.BLL.DTO
{
    public class CommentDto
    {
        public long Id { get; set; }
        public string CommentBody { get; set; }
        public long ProductId { get; set; }
        public DateTime? DateComment { get; set; }
        public virtual UserDto ApplicationUser { get; set; }
    }
}
