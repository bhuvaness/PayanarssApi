using ProductManagementModule.Models;

namespace ProductManagementModule.DTOs
{
    public class ProductCategoryDto : DataModel 
    {
        private string name;
        public string Name { get => name; set { name = value; MarkDirty(); } }
    }
}
