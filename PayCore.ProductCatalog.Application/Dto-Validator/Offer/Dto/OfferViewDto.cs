using PayCore.ProductCatalog.Domain.Entities;
using System;


namespace PayCore.ProducCatalog.Application.Dto_Validator
{
    public class OfferViewDto
    {
        public virtual int Id { get; set; }
        public int OfferedPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public bool IsApproved { get; set; }
    }
}
