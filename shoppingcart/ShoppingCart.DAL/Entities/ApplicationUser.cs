using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCart.DAL.CustomIdentity;

namespace ShoppingCart.DAL.Entities
{
    public class ApplicationUser : IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim>//+
    {
        public ApplicationUser()
        {
            Bascets = new HashSet<Bascet>();
            Comments = new HashSet<Comment>();
        }

        [Column(TypeName = "date")]
        public DateTime? RegDate { get; set; }

        public virtual ICollection<Bascet> Bascets { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
