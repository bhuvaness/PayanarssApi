using CommonTechnologyModule.Repositories;
using CommonTechnologyModule.Services;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanTypeService : IBaseService<PlanType> { }

    public class PlanTypeService : Service<PlanType>, IPlanTypeService
    {
        public PlanTypeService(IPlanTypeRepository repository) : base(repository)
        {
        }
    }
}
