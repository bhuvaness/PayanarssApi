using PayanarssProductModules.Models;

namespace PayanarssProductModules.DTOs
{
    public class ProductProductTypeMapDto : DataModel
    {
        public string ProductId { get; set; }
        public ProductDto Product { get; set; }

        public string ProductTypeId { get; set; }
        public ProductTypeDto ProductType { get; set; }
    }
}
