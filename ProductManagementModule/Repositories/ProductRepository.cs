// Implementation of ProductRepository
using ProductManagementModule.Models;
using Microsoft.EntityFrameworkCore;
using ProductManagementModule.Data;

namespace ProductManagementModule.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            // Add the main product entity after related entities are added
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            // Update the main product entity
            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(c => c.Id == id);

            if (product == null)
                return false;

            // Remove the product
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Products.AnyAsync(c => c.Id == id);
        }
    }
}