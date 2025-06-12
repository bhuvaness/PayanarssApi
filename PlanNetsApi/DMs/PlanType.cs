using CommonTechnologyModule.DataModels;

namespace PlanNetsModule.DMs
{
    public class PlanType : NamedDataModel
    {
        public string Description { get; set; }

        public ICollection<Plan> Plans { get; set; }
    }
}
