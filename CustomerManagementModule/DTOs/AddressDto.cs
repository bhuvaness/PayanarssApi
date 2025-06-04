using CustomerManagementModule.Models;

namespace CustomerManagementModule.DTOs
{
    public class AddressDto : DataModel
    {
        private string addressLine1;
        private string? addressLine2;
        private string city;
        private string state;
        private string postalCode;
        private string country;

        public string AddressLine1 { get => addressLine1; set { addressLine1 = value; MarkDirty(); } }
        public string? AddressLine2 { get => addressLine2; set { addressLine2 = value; MarkDirty(); } }
        public string City { get => city; set { city = value; MarkDirty(); } }
        public string State { get => state; set { state = value; MarkDirty(); } }
        public string PostalCode { get => postalCode; set { postalCode = value; MarkDirty(); } }
        public string Country { get => country; set { country = value; MarkDirty(); } }

        public ICollection<CustomerAddressMapDto> CustomerMappings { get; set; }
    }
}
