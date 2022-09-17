using AutoMapper;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Interfaces.Log;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Services
{
    public class BrandService : IBrandService
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork ;


        public BrandService(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;

        }

        //GetAll
        public async Task<IEnumerable<BrandViewDto>> GetAll()
        {
            var tempEntity = await unitOfWork.Brand.GetAll();
            var result = mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewDto>>(tempEntity);
            return result;
        }

        //GetById
        public async Task<BrandViewDto> GetById(int id)
        {
            var entity = await unitOfWork.Brand.GetById(id);

            if(entity is null)
            {
                throw new NotFoundException(nameof(Brand), id);
            }

            var result = mapper.Map<Brand, BrandViewDto>(entity);
            return result;
        }

        //Insert
        public async Task Insert(BrandUpsertDto dto)
        {
            var tempEntity = mapper.Map<BrandUpsertDto, Brand>(dto);
            await unitOfWork.Brand.Create(tempEntity);
        }

        //Remove
        public async Task Remove(int id)
        {
            var entity = await unitOfWork.Brand.GetById(id);

            if(entity is null)
            {
                throw new NotFoundException(nameof(Brand),id);
            }
            
            //IsDeleted field of brand is updated to delete. 
            //Assuming product might have used this brand id. The brand is not delted from database 
            await unitOfWork.Brand.Update(entity);
        }

        //Update
        public async Task Update(int id, BrandUpsertDto dto)
        {
           var tempentity = await unitOfWork.Brand.GetById(id);
           if(tempentity is null)
            {
                throw new NotFoundException(nameof(Brand), id);
            }
            if (dto.BrandName is not null)
                tempentity.BrandName = dto.BrandName;

            await unitOfWork.Brand.Update(tempentity);
        }

    }
}
