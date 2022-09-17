using AutoMapper;
using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;


        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

        }

        //GetAll
        public async Task<IEnumerable<ProductViewDto>> GetAll()
        {
            var tempEntity = await _unitOfWork.Product.GetAll();
            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewDto>>(tempEntity);
            return result;
        }

        //GetById
        public async Task<ProductViewDto> GetById(int id)
        {
            var entity = await _unitOfWork.Product.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Product), id);
            }

            var result = _mapper.Map<Product, ProductViewDto>(entity);
            return result;
        }

        //Insert
        public async Task Insert(ProductUpsertDto dto)
        {
            var tempEntity = _mapper.Map<ProductUpsertDto, Product>(dto);
            await _unitOfWork.Product.Create(tempEntity);
        }

        //Remove
        public async Task Remove(int id)
        {
            var entity = await _unitOfWork.Product.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Product), id);
            }

            //IsDeleted field of brand is updated to delete. 
            //Assuming product might have used this brand id. The brand is not deleted from database 
            await _unitOfWork.Product.Update(entity);
        }

        //Update
        public async Task Update(int id, ProductUpsertDto dto)
        {
            var tempentity = await _unitOfWork.Offer.GetById(id);
            if (tempentity is null)
            {
                throw new NotFoundException(nameof(Product), id);
            }
            await _unitOfWork.Offer.Update(tempentity);
        }

    }
}
