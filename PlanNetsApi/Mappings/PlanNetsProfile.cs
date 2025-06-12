using AutoMapper;
using PlanNetsModule.DMs;
using PlanNetsModule.DTOs;

namespace PlanNetsModule.Mappings
{
    public class PlanNetsProfile : Profile
    {
        public PlanNetsProfile()
        {
            //CreateMap<PlanDto, Plan>().ReverseMap();

            CreateMap<Plan, PlanDto>().ReverseMap();
            CreateMap<PlanType, PlanTypeDto>().ReverseMap();
            CreateMap<PlanPurpose, PlanPurposeDto>().ReverseMap();
            CreateMap<PlanStatus, PlanStatusDto>().ReverseMap();
        }
    }
}
