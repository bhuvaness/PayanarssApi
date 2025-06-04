namespace CustomerManagementModule.Models
{
    public class Customer : DataModel
    {
        private string name;
        private string? email;
        private string? phone;

        public string Name { get => name; set { name = value; MarkDirty(); } }
        public string? Email { get => email; set { email = value; MarkDirty(); } }
        public string? Phone { get => phone; set { phone = value; MarkDirty(); } }

        public ICollection<CustomerType> CustomerTypes { get; set; }
        public ICollection<CustomerAddressMap> CustomerAddresses { get; set; }
        public ICollection<CustomerContact> Contacts { get; set; }
    }
}
