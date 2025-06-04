using PayanarssCustomerModules.Models;

namespace PayanarssCustomerModules.DTOs
{
    public class CustomerCustomerTypeMapDto : DataModel
    {
        public string CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public string CustomerTypeId { get; set; }
        public CustomerTypeDto CustomerType { get; set; }
    }
}
