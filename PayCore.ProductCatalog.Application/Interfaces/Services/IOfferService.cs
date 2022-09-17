using PayCore.ProductCatalog.Application.Dto_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferViewDto>> GetAll();
        Task<OfferViewDto> GetById(int id);
        Task Insert(OfferUpsertDto dto);
        Task Remove(int id);
        Task Update(int id, OfferUpsertDto dto);
    }
}
