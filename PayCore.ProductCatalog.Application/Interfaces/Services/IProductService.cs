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
        Task InsertOfferableProduct(int userId,ProductUpsertDto dto);

        //Remove product
        Task Remove(int userId,int id);

        //Update product
        Task Update(int userId,int id, ProductUpsertDto dto);
    }
}
