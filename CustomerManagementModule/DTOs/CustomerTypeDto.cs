using CustomerManagementModule.Models;

namespace CustomerManagementModule.DTOs
{
    public class CustomerTypeDto : DataModel
    {
        private string typeName;

        public string TypeName { get => typeName; set { typeName = value; MarkDirty(); } }
    }
}
