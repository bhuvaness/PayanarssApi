using CommonTechnologyModule.Services;
using PlanNetsModule.DMs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanService : IBaseService<Plan> { }

    public class PlanService : Service<Plan>, IPlanService
    {
        public PlanService(IPlanRepository repository):base(repository)
        {
        }
    }
}
