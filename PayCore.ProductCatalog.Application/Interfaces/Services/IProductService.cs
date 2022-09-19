using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Services
{
    public interface IProductService
    {
        //Fetches all products
        Task<IEnumerable<ProductViewDto>> GetAll();

        //Get product with id
        Task<ProductViewDto> GetById(int id);

        //Insert offerable Product 
        Task InsertProduct(int userId,ProductUpsertDto dto);

        //Remove product
        Task Remove(int productId,int userId);

        //Update product
        Task Update(int productId, int userId, ProductUpsertDto dto);
    }
}
