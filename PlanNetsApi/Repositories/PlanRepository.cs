using CommonTechnologyModule.Repositories;
using Microsoft.EntityFrameworkCore;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;

namespace PlanNetsModule.Repositories
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        private readonly PlanNetsDbContext _context;

        public PlanRepository(PlanNetsDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Plan>> GetAllAsync()
        {
            return await _context.Plans
                .Include(p => p.PlanType)
                .Include(p => p.PlanStatus)
                .ToListAsync();
        }

        public override async Task<Plan> GetByIdAsync(string id)
        {
            return await _context.Plans
                .Include(p => p.PlanType)
                .Include(p => p.PlanStatus)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
