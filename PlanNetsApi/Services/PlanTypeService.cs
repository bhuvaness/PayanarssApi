using AutoMapper;
using CommonTechnologyModule.Repositories;
using CommonTechnologyModule.Services;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.DMs;
using PlanNetsModule.DTOs;
using PlanNetsModule.Repositories;

namespace PlanNetsModule.Services
{
    public interface IPlanTypeService : IBaseService<PlanTypeDto, PlanType> { }

    public class PlanTypeService : NamedSearchService<PlanTypeDto, PlanType>, IPlanTypeService
    {
        public PlanTypeService(IPlanTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
