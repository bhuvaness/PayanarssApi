using CommonTechnologyModule.DataModels;

namespace PlanNetsModule.DMs
{
    public class Plan : DataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string PlanTypeId { get; set; }
        public PlanType PlanType { get; set; }
        public string PlanPurposeId { get; set; }
        public PlanPurpose PlanPurpose { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }

        public string PlanStatusId { get; set; }
        public PlanStatus PlanStatus { get; set; }
    }
}
