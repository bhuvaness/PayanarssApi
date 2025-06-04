namespace ProductManagementModule.Models
{
    public class ProductCategory : DataModel
    {
        private string name;
        public string Name { get => name; set { name = value; MarkDirty(); } }
    }
}
