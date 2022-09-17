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
    public class OfferService : IOfferService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;


        public OfferService(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

        }

        //GetAll
        public async Task<IEnumerable<OfferViewDto>> GetAll()
        {
            var tempEntity = await _unitOfWork.Offer.GetAll();
            var result = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferViewDto>>(tempEntity);
            return result;
        }

        //GetById
        public async Task<OfferViewDto> GetById(int id)
        {
            var entity = await _unitOfWork.Offer.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Offer), id);
            }

            var result = _mapper.Map<Offer, OfferViewDto>(entity);
            return result;
        }

        //Insert
        public async Task Insert(OfferUpsertDto dto)
        {
            var tempEntity = _mapper.Map<OfferUpsertDto, Offer>(dto);
            await _unitOfWork.Offer.Create(tempEntity);
        }

        //Remove
        public async Task Remove(int id)
        {
            var entity = await _unitOfWork.Offer.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Offer), id);
            }

            //IsDeleted field of brand is updated to delete. 
            //Assuming product might have used this brand id. The brand is not deleted from database 
            await _unitOfWork.Offer.Update(entity);
        }

        //Update
        public async Task Update(int id, OfferUpsertDto dto)
        {
            var tempentity = await _unitOfWork.Offer.GetById(id);
            if (tempentity is null)
            {
                throw new NotFoundException(nameof(Offer), id);
            }
            if (dto.OfferedPrice != tempentity.OfferedPrice)
                tempentity.OfferedPrice = dto.OfferedPrice;
            await _unitOfWork.Offer.Update(tempentity);
        }

    }
}
