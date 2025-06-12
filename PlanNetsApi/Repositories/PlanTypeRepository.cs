using CommonTechnologyModule.Repositories;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;

namespace PlanNetsModule.Repositories
{
    public class PlanTypeRepository : Repository<PlanType>, IPlanTypeRepository
    {
        public PlanTypeRepository(PlanNetsDbContext context) : base(context) { }
    }
}
