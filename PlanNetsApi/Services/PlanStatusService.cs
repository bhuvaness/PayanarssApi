using CommonTechnologyModule.Repositories;
using CommonTechnologyModule.Services;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanStatusService : IBaseService<PlanStatus> { }

    public class PlanStatusService : Service<PlanStatus>, IPlanStatusService
    {
        public PlanStatusService(IPlanStatusRepository repository) : base(repository)
        {
        }
    }
}
