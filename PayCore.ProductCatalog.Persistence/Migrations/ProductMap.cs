using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCore.ProductCatalog.Domain.Entities;


namespace PayCore.ProductCatalog.Persistence.Migrations
{
    public class ProductMap:ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.CreatedAt, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });

            Property(x => x.IsDeleted, x =>
            {
                x.Type(NHibernateUtil.Boolean);
            });

            Property(b => b.ProductName, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
        

            Property(x => x.IsSold, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);

            });
            Property(x => x.UsingStatus, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);

            });

            Property(x => x.CategoryId, x =>
            {
                x.Type(NHibernateUtil.Int32);
            });

            Property(x => x.ColorId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(false);// Brand Id can be null
            });

            Property(x => x.BrandId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(false); // Brand Id can be null
            });

            Property(x => x.AccountId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
        }
    }
}
