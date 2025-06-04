namespace CustomerManagementModule.Models
{
    public class CustomerContact : DataModel
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        private string contactName;
        private string? email;
        private string? phone;
        private string? role;

        public string ContactName { get => contactName; set { contactName = value; MarkDirty(); } }
        public string? Email { get => email; set { email = value; MarkDirty(); } }
        public string? Phone { get => phone; set { phone = value; MarkDirty(); } }
        public string? Role { get => role; set { role = value; MarkDirty(); } }
    }
}
