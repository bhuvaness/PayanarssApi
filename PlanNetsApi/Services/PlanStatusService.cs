using AutoMapper;
using CommonTechnologyModule.Repositories;
using CommonTechnologyModule.Services;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;
using PlanNetsModule.DTOs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanStatusService : IBaseService<PlanStatusDto, PlanStatus> { }

    public class PlanStatusService : NamedSearchService<PlanStatusDto, PlanStatus>, IPlanStatusService
    {
        public PlanStatusService(IPlanStatusRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
