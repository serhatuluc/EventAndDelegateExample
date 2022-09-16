using System;


namespace PayCore.ProductCatalog.Application.Dto_Validator
{
    class OfferViewDto
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public int OfferedPrice { get; set; }
        public int ProductId { get; set; }
        public int IsApproved { get; set; }
    }
}
