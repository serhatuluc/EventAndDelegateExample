using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCore.ProductCatalog.Domain.Entities;


namespace PayCore.ProductCatalog.Persistence.Migrations
{
    public class OfferMap:ClassMapping<Offer>
    {
        public OfferMap()
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
                x.NotNullable(true);
            });

            Property(x => x.IsApproved, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });


            Property(x => x.OfferedPrice, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(x => x.ProductId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(x => x.AccountId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(false);
            });
            Table("offer");
        }
    }
}
