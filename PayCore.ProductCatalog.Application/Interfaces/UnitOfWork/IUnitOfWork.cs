using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBrandRepository Brand { get; }
        ICategoryRepository Category { get; }
        IColorRepository Color { get; }
        IProductRepository Product { get; }
        IOfferRepository Offer { get; }
    }
}
