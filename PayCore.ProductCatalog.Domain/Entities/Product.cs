

using System.Collections.Generic;

namespace PayCore.ProductCatalog.Domain.Entities
{
    public class Product:BaseEntity
    {
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsSold { get; set; } = false;
        public virtual bool IsOfferable { get; set; } = true;
        public virtual Category Category { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual int BrandId { get; set; }
        public virtual Color Color { get; set; }
        public virtual int ColorId { get; set; }
        public virtual Account Account { get; set; }
        public virtual int AccountId { get; set; }
        public virtual int Price { get; set; }
        public virtual IList<Offer> Offers { get; set; }
    }
}
