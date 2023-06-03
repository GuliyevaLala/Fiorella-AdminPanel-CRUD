using BackToFiorello.Models;

namespace BackToFiorello.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
