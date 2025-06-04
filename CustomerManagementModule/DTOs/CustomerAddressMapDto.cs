using CustomerManagementModule.Models;

namespace CustomerManagementModule.DTOs
{
    public class CustomerAddressMapDto : DataModel
    {
        public string CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public string AddressId { get; set; }
        public AddressDto Address { get; set; }

        private bool isPrimary;
        private string? addressType;

        public bool IsPrimary { get => isPrimary; set { isPrimary = value; MarkDirty(); } }
        public string? AddressType { get => addressType; set { addressType = value; MarkDirty(); } }
    }
}
