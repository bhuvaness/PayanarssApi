namespace ProductManagementModule.Models
{
    public class Product : DataModel
    {
        private string name;
        private string? email;
        private string? phone;
        public string CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public string UnitId { get; set; }
        public ProductUnit Address { get; set; }
        public string Name { get => name; set { name = value; MarkDirty(); } }
        public string? Email { get => email; set { email = value; MarkDirty(); } }
        public string? Phone { get => phone; set { phone = value; MarkDirty(); } }
    }
}
