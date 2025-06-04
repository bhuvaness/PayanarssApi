namespace CustomerManagementModule.Models
{
    public class CustomerAddressMap : DataModel
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }

        private bool isPrimary;
        private string? addressType;

        public bool IsPrimary { get => isPrimary; set { isPrimary = value; MarkDirty(); } }
        public string? AddressType { get => addressType; set { addressType = value; MarkDirty(); } }
    }
}
