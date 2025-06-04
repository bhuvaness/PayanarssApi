namespace ProductManagementModule.Models
{
    public class ProductUnit : DataModel
    {
        private string name;
        public string Name { get => name; set { name = value; MarkDirty(); } }
    }
}
