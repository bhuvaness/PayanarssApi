using AutoMapper;
using CommonTechnologyModule.Services;
using PlanNetsModule.DMs;
using PlanNetsModule.DTOs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanPurposeService : IBaseService<PlanPurposeDto, PlanPurpose> { }

    public class PlanPurposeService : NamedSearchService<PlanPurposeDto, PlanPurpose>, IPlanPurposeService
    {
        public PlanPurposeService(IPlanPurposeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
