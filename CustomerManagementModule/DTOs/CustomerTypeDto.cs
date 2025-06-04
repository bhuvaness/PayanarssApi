using CustomerManagementModule.Models;

namespace CustomerManagementModule.DTOs
{
    public class CustomerTypeDto : DataModel
    {
        public string CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        private string typeName;

        public string TypeName { get => typeName; set { typeName = value; MarkDirty(); } }
    }
}
