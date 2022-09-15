﻿

namespace PayCore.ProductCatalog.Domain.Entities
{
    public class Product:BaseEntity
    {
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsSold { get; set; } = false;
        public virtual bool UsingStatus { get; set; } = false;
        public virtual int CategoryId { get; set; }
        public virtual int BrandId { get; set; }
        public virtual int ColorId { get; set; }
        public virtual int AccountId { get; set; }
    }
}
