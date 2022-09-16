using PayCore.ProductCatalog.Application.Dto_Validator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Services
{
    public interface IBrandService 
    {
        Task<IEnumerable<BrandViewDto>> GetAll();
        Task<BrandViewDto> GetById(int id);
        Task<BrandUpsertDto> Insert(BrandUpsertDto dto);
        Task Remove(int id);
        Task<BrandUpsertDto> Update(int id, BrandUpsertDto dto);
    }
    
}
