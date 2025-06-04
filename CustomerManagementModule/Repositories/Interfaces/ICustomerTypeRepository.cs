using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementModule.Models;

namespace CustomerManagementModule.Repositories
{
    public interface ICustomerTypeRepository
    {
        Task<IEnumerable<CustomerType>> GetAllAsync();
        Task<CustomerType?> GetByIdAsync(string id);
        Task<CustomerType> AddAsync(CustomerType type);
        Task UpdateAsync(CustomerType type);
        Task DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}
