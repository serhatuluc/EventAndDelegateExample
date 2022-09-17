using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<BrandViewDto>> GetAll();
        Task<BrandViewDto> GetById(int id);
        Task Insert(BrandUpsertDto dto);
        Task Remove(int id);
        Task Update(int id, BrandUpsertDto dto);
    }
}
