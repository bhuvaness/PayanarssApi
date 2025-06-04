namespace CustomerManagementModule.Models
{
    public class CustomerType : DataModel
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        private string typeName;

        public string TypeName { get => typeName; set { typeName = value; MarkDirty(); } }
    }
}
