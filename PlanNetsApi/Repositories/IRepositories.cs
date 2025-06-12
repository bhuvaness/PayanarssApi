using CommonTechnologyModule.Repositories;
using PlanNetsModule.DMs;

namespace PlanNetsModule.Repositories
{
    public interface IPlanRepository : IRepository<Plan> { }
    public interface IPlanTypeRepository : IRepository<PlanType> { }
    public interface IPlanPurposeRepository : IRepository<PlanPurpose> { }
    public interface IPlanStatusRepository : IRepository<PlanStatus> { }
}
