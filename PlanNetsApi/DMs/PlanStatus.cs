using CommonTechnologyModule.DataModels;

namespace PlanNetsModule.DMs
{
    public class PlanStatus : DataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Plan> Plans { get; set; }
    }

}
