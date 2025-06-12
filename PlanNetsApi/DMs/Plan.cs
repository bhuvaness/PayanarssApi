using CommonTechnologyModule.DataModels;

namespace PlanNetsModule.DMs
{
    public class Plan : NamedDataModel
    {
        public string Description { get; set; }

        public string PlanTypeId { get; set; }
        public PlanType? PlanType { get; set; }
        public string PlanPurposeId { get; set; }
        public PlanPurpose? PlanPurpose { get; set; }
        public string FromDateTime { get; set; }
        public string ToDateTime { get; set; }

        public string PlanStatusId { get; set; }
        public PlanStatus? PlanStatus { get; set; }
    }
}
