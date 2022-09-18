
namespace PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto
{
   public class ProductViewDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public double Price { get; set; }
    }
}
