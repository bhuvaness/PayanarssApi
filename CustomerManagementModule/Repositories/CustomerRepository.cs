// Implementation of CustomerRepository
using CustomerManagementModule.Models;
using Microsoft.EntityFrameworkCore;
using CustomerManagementModule.Data;

namespace CustomerManagementModule.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(c => c.CustomerTypes)
                .Include(c => c.CustomerAddresses)
                    .ThenInclude(ca => ca.Address)
                .Include(c => c.Contacts)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(string id)
        {
            return await _context.Customers
                .Include(c => c.CustomerTypes)
                .Include(c => c.CustomerAddresses)
                    .ThenInclude(ca => ca.Address)
                .Include(c => c.Contacts)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            if (customer.CustomerAddresses != null && customer.CustomerAddresses.Any())
                await _context.CustomerAddressMaps.AddRangeAsync(customer.CustomerAddresses);

            if (customer.Contacts != null && customer.Contacts.Any())
                await _context.CustomerContacts.AddRangeAsync(customer.Contacts);

            if (customer.CustomerTypes != null && customer.CustomerTypes.Any())
                await _context.CustomerTypes.AddRangeAsync(customer.CustomerTypes);

            // Add the main customer entity after related entities are added
            await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            // Update the main customer entity
            _context.Customers.Update(customer);

            // Optionally clear existing child records before adding new ones
            if (customer.CustomerAddresses != null && customer.CustomerAddresses.Any())
            {
                _context.CustomerAddressMaps.RemoveRange(
                    _context.CustomerAddressMaps.Where(a => a.CustomerId == customer.Id));
                await _context.CustomerAddressMaps.AddRangeAsync(customer.CustomerAddresses);
            }

            if (customer.Contacts != null && customer.Contacts.Any())
            {
                _context.CustomerContacts.RemoveRange(
                    _context.CustomerContacts.Where(c => c.CustomerId == customer.Id));
                await _context.CustomerContacts.AddRangeAsync(customer.Contacts);
            }

            if (customer.CustomerTypes != null && customer.CustomerTypes.Any())
            {
                _context.CustomerTypes.RemoveRange(
                    _context.CustomerTypes.Where(ct => ct.CustomerId == customer.Id));
                await _context.CustomerTypes.AddRangeAsync(customer.CustomerTypes);
            }

            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var customer = await _context.Customers
                .Include(c => c.CustomerAddresses)
                .Include(c => c.Contacts)
                .Include(c => c.CustomerTypes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return false;

            // Remove related child entities first
            if (customer.CustomerAddresses != null && customer.CustomerAddresses.Any())
            {
                _context.CustomerAddressMaps.RemoveRange(customer.CustomerAddresses);
            }

            if (customer.Contacts != null && customer.Contacts.Any())
            {
                _context.CustomerContacts.RemoveRange(customer.Contacts);
            }

            if (customer.CustomerTypes != null && customer.CustomerTypes.Any())
            {
                _context.CustomerTypes.RemoveRange(customer.CustomerTypes);
            }

            // Remove the customer
            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Customers.AnyAsync(c => c.Id == id);
        }
    }
}