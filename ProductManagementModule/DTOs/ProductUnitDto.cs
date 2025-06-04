using ProductManagementModule.Models;

namespace ProductManagementModule.DTOs
{
    public class ProductUnitDto : DataModel
    {
        private string name;
        public string Name { get => name; set { name = value; MarkDirty(); } }
    }
}
