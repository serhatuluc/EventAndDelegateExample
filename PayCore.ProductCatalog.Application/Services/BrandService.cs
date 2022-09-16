using AutoMapper;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Services
{
    public class BrandService : IBrandService
    {
        protected readonly IMapper mapper;
        protected readonly IBrandRepository brandRepository;


        public BrandService(IMapper mapper, IBrandRepository brandRepository) : base()
        {
            this.mapper = mapper;
            this.brandRepository = brandRepository;

        }
        public async Task<IEnumerable<BrandViewDto>> GetAll()
        {
            var tempEntity = await brandRepository.GetAll();
            var result = mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewDto>>(tempEntity);
            return result;
        }

        public Task<BrandViewDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BrandUpsertDto> Insert(BrandUpsertDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BrandUpsertDto> Update(int id, BrandUpsertDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
