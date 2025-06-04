using Microsoft.EntityFrameworkCore;
using CustomerManagementModule.Data;
using CustomerManagementModule.Models;
using CustomerManagementModule.Repositories;

namespace CustomerManagementModule.Repositories
{
    public class CustomerContactRepository : ICustomerContactRepository
    {
        private readonly AppDbContext _context;

        public CustomerContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerContact>> GetAllAsync() =>
            await _context.CustomerContacts.ToListAsync();

        public async Task<CustomerContact?> GetByIdAsync(string id) =>
            await _context.CustomerContacts.FindAsync(id);

        public async Task<CustomerContact> AddAsync(CustomerContact contact)
        {
            _context.CustomerContacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task UpdateAsync(CustomerContact contact)
        {
            _context.CustomerContacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var contact = await _context.CustomerContacts.FindAsync(id);
            if (contact != null)
            {
                _context.CustomerContacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id) =>
            await _context.CustomerContacts.AnyAsync(c => c.Id == id);
    }
}
