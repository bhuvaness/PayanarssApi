using CustomerManagementModule.Models;

namespace CustomerManagementModule.DTOs
{
    public class CustomerDto : DataModel
    {
        private string name;
        private string? email;
        private string? phone;

        public string Name { get => name; set { name = value; MarkDirty(); } }
        public string? Email { get => email; set { email = value; MarkDirty(); } }
        public string? Phone { get => phone; set { phone = value; MarkDirty(); } }

        public ICollection<CustomerTypeDto> CustomerTypes { get; set; }
        public ICollection<CustomerAddressMapDto> CustomerAddresses { get; set; }
        public ICollection<CustomerContactDto> Contacts { get; set; }
    }
}
