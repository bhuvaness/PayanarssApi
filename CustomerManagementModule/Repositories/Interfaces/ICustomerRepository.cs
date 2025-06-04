// Interface for CustomerRepository
using CustomerManagementModule.Models;

namespace CustomerManagementModule.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(string id);
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}