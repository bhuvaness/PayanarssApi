using CommonTechnologyModule.Repositories;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;

namespace PlanNetsModule.Repositories
{
    public class PlanPurposeRepository : Repository<PlanPurpose>, IPlanPurposeRepository
    {
        public PlanPurposeRepository(PlanNetsDbContext context) : base(context) { }
    }
}
