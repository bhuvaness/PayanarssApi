using CommonTechnologyModule.DataModels;

namespace PlanNetsModule.DTOs
{
    public class PlanDto : NamedDataModel
    {
        public string Description { get; set; }

        public string PlanTypeId { get; set; }
        public PlanTypeDto PlanType { get; set; }
        public string PlanPurposeId { get; set; }
        public PlanPurposeDto PlanPurpose { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }

        public string PlanStatusId { get; set; }
        public PlanStatusDto PlanStatus { get; set; }
    }
}
