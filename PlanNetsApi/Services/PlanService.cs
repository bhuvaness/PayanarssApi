using AutoMapper;
using CommonTechnologyModule.Services;
using PlanNetsModule.DMs;
using PlanNetsModule.DTOs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanService : IBaseService<PlanDto, Plan> { }

    public class PlanService : NamedSearchService<PlanDto, Plan>, IPlanService
    {
        public PlanService(IPlanRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
