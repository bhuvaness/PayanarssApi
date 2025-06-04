using Microsoft.EntityFrameworkCore;
using CustomerManagementModule.Data;
using CustomerManagementModule.Models;
using CustomerManagementModule.Repositories;

namespace CustomerManagementModule.Repositories
{
    public class CustomerTypeRepository : ICustomerTypeRepository
    {
        private readonly AppDbContext _context;

        public CustomerTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerType>> GetAllAsync() =>
            await _context.CustomerTypes.ToListAsync();

        public async Task<CustomerType?> GetByIdAsync(string id) =>
            await _context.CustomerTypes.FindAsync(id);

        public async Task<CustomerType> AddAsync(CustomerType type)
        {
            _context.CustomerTypes.Add(type);
            await _context.SaveChangesAsync();
            return type;
        }

        public async Task UpdateAsync(CustomerType type)
        {
            _context.CustomerTypes.Update(type);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var type = await _context.CustomerTypes.FindAsync(id);
            if (type != null)
            {
                _context.CustomerTypes.Remove(type);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id) =>
            await _context.CustomerTypes.AnyAsync(t => t.Id == id);
    }
}
