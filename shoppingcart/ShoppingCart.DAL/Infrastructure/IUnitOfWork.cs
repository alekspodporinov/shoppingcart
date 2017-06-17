using System.Threading.Tasks;

namespace ShoppingCart.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
