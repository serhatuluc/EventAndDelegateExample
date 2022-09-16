﻿using AutoMapper;
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
    public class CategoryService : ICategoryService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;


        public CategoryService(IMapper mapper,IUnitOfWork unitOfWork) : base()
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

        }

        //GetAll
        public async Task<IEnumerable<CategoryViewDto>> GetAll()
        {
            var tempEntity = await _unitOfWork.Category.GetAll();
            var result = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewDto>>(tempEntity);
            return result;
        }

        //GetById
        public async Task<CategoryViewDto> GetById(int id)
        {
            var entity = await _unitOfWork.Category.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Category), id);
            }

            var result = _mapper.Map<Category, CategoryViewDto>(entity);
            return result;
        }

        //Insert
        public async Task Insert(CategoryUpsertDto dto)
        {
            var tempEntity = _mapper.Map<CategoryUpsertDto, Category>(dto);
            await _unitOfWork.Category.Create(tempEntity);
        }

        //Remove
        public async Task Remove(int id)
        {
            var entity = await _unitOfWork.Category.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Category), id);
            }

            //IsDeleted field of brand is updated to delete. 
            //Assuming product might have used this brand id. The brand is not deleted from database 
            entity.IsDeleted = true;
            await _unitOfWork.Category.Update(entity);
        }

        //Update
        public async Task Update(int id, CategoryUpsertDto dto)
        {
            var tempentity = await _unitOfWork.Category.GetById(id);
            if (tempentity is null)
            {
                throw new NotFoundException(nameof(Category), id);
            }
            if (dto.CategoryName is not null)
                tempentity.CategoryName = dto.CategoryName;
            await _unitOfWork.Category.Update(tempentity);
        }

    }
}