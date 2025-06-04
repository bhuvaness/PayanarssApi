// Interface for ProductRepository
using ProductManagementModule.Models;

namespace ProductManagementModule.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(string id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}