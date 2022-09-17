using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewDto>> GetAll();
        Task<ProductViewDto> GetById(int id);
        Task Insert(ProductUpsertDto dto);
        Task Remove(int id);
        Task Update(int id, ProductUpsertDto dto);
    }
}
