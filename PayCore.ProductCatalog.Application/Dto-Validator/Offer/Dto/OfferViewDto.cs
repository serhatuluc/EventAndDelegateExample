using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;


namespace PayCore.ProducCatalog.Application.Dto_Validator
{
    public class OfferViewDto
    {
        public virtual int Id { get; set; }
        public int OfferedPrice { get; set; }
        public ProductViewDto Product { get; set; }
        public bool IsApproved { get; set; }
    }
}
