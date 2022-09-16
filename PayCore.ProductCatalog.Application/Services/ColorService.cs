using AutoMapper;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Services
{
    public class ColorService : IColorService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;


        public ColorService(IMapper mapper, IUnitOfWork unitOfWork) : base()
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

        }

        //GetAll
        public async Task<IEnumerable<ColorViewDto>> GetAll()
        {
            var tempEntity = await _unitOfWork.Color.GetAll();
            var result = _mapper.Map<IEnumerable<Color>, IEnumerable<ColorViewDto>>(tempEntity);
            return result;
        }

        //GetById
        public async Task<ColorViewDto> GetById(int id)
        {
            var entity = await _unitOfWork.Color.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Color), id);
            }

            var result = _mapper.Map<Color, ColorViewDto>(entity);
            return result;
        }

        //Insert
        public async Task Insert(ColorUpsertDto dto)
        {
            var tempEntity = _mapper.Map<ColorUpsertDto, Color>(dto);
            await _unitOfWork.Color.Create(tempEntity);
        }

        //Remove
        public async Task Remove(int id)
        {
            var entity = await _unitOfWork.Color.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Color), id);
            }

            //IsDeleted field of brand is updated to delete. 
            //Assuming product might have used this brand id. The brand is not deleted from database 
            entity.IsDeleted = true;
            await _unitOfWork.Color.Update(entity);
        }

        //Update
        public async Task Update(int id, ColorUpsertDto dto)
        {
            var tempentity = await _unitOfWork.Color.GetById(id);
            if (tempentity is null)
            {
                throw new NotFoundException(nameof(Color), id);
            }
            if (dto.ColorName is not null)
                tempentity.ColorName= dto.ColorName;
            await _unitOfWork.Color.Update(tempentity);
        }

    }
}
