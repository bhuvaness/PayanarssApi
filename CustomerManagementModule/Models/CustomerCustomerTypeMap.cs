namespace CustomerManagementModule.Models
{
    public class CustomerCustomerTypeMap : DataModel
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
