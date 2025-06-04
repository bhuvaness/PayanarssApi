using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementModule.Models;

namespace CustomerManagementModule.Repositories
{
    public interface ICustomerContactRepository
    {
        Task<IEnumerable<CustomerContact>> GetAllAsync();
        Task<CustomerContact?> GetByIdAsync(string id);
        Task<CustomerContact> AddAsync(CustomerContact contact);
        Task UpdateAsync(CustomerContact contact);
        Task DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}
