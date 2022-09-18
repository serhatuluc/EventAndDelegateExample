

namespace PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto
{
    public class ProductUpsertDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsSold { get; set; }
        public bool IsOfferable { get; set; }
    }
}
