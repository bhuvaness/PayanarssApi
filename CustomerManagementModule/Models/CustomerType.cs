namespace CustomerManagementModule.Models
{
    public class CustomerType : DataModel
    {
        private string typeName;

        public string TypeName { get => typeName; set { typeName = value; MarkDirty(); } }

        public ICollection<CustomerCustomerTypeMap> CustomerMappings { get; set; }
    }
}
