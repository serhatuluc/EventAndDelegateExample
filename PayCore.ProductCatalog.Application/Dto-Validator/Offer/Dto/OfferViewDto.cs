using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Dto_Validator.Offer.Dto
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
