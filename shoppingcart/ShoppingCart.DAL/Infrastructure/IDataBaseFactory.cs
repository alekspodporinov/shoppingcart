using System;
using ShoppingCart.DAL.EF;

namespace ShoppingCart.DAL.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationDbContext Get();
    }

}
