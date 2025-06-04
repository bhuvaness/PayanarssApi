using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementModule.Models;

namespace CustomerManagementModule.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address?> GetByIdAsync(string id);
        Task<Address> AddAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}
