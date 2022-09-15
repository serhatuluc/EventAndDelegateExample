using System;


namespace PayCore.ProductCatalog.Domain.Entities
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
    }
}
