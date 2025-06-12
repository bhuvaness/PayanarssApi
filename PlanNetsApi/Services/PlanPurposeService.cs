using CommonTechnologyModule.Services;
using PlanNetsModule.DMs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanPurposeService : IBaseService<PlanPurpose> { }

    public class PlanPurposeService : Service<PlanPurpose>, IPlanPurposeService
    {
        public PlanPurposeService(IPlanPurposeRepository repository) : base(repository)
        {
        }
    }
}
