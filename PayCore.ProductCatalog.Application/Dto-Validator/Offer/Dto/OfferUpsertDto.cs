using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Dto_Validator.Offer.Dto
{
    public class OfferUpsertDto
    {
        public virtual int OfferedPrice { get; set; }
        public virtual int ProductId { get; set; }
    }
}
