using CommonTechnologyModule.Repositories;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;

namespace PlanNetsModule.Repositories
{
    public class PlanStatusRepository : Repository<PlanStatus>, IPlanStatusRepository
    {
        public PlanStatusRepository(PlanNetsDbContext context) : base(context) { }
    }
}
