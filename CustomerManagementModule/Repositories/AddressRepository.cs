using Microsoft.EntityFrameworkCore;
using CustomerManagementModule.Data;
using CustomerManagementModule.Models;
using CustomerManagementModule.Repositories;

namespace CustomerManagementModule.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAsync() =>
            await _context.Addresses.ToListAsync();

        public async Task<Address?> GetByIdAsync(string id) =>
            await _context.Addresses.FindAsync(id);

        public async Task<Address> AddAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id) =>
            await _context.Addresses.AnyAsync(a => a.Id == id);
    }
}
