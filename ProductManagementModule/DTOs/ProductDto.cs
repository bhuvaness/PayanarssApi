using ProductManagementModule.Models;

namespace ProductManagementModule.DTOs
{
    public class ProductDto : DataModel
    {
        private string name;
        private string? description;
        private string? hsnCode;
        public string CategoryId { get; set; }
        public ProductCategoryDto Category { get; set; }
        public string UnitId { get; set; }
        public ProductUnitDto Unit { get; set; }
        public string Name { get => name; set { name = value; MarkDirty(); } }
        public string? Email { get => description; set { description = value; MarkDirty(); } }
        public string? Phone { get => hsnCode; set { hsnCode = value; MarkDirty(); } }
    }
}
