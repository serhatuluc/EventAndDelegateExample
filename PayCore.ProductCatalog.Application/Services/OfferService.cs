using AutoMapper;
using PayCore.ProductCatalog.Application.Common.Exceptions;
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


        ////GetById
        //public async Task<OfferViewDto> GetById(int id)
        //{
        //    var entity = await _unitOfWork.Offer.GetById(id);

        //    if (entity is null)
        //    {
        //        throw new NotFoundException(nameof(Offer), id);
        //    }

        //    var result = _mapper.Map<Offer, OfferViewDto>(entity);
        //    return result;
        //}

        public async Task<IEnumerable<Offer>> GetOffersForUser(int userId)
        {
            //Fetch all the offers with id of user
            return await _unitOfWork.Offer.GetAll(x=>x.AccountId==userId);
        }

        //Insert
        public async Task OfferOnProduct(int userId,OfferUpsertDto dto)
        {
            //To check if product is offerable
            var product = await _unitOfWork.Product.GetById(dto.ProductId);
            if (product.IsOfferable == false)
            {
                throw new BadRequestException("Product is not offerable");
            }
            //Mapping dto to entity
            var tempEntity = _mapper.Map<OfferUpsertDto, Offer>(dto);

            //Assigning id of user to AccountId
            tempEntity.AccountId = userId;

            //Creating the offer
            await _unitOfWork.Offer.Create(tempEntity);
        }

        //Remove
        public async Task WithDrawOffer(int UserId, int offerId)
        {
            //Fetch the offer
            var entity = await _unitOfWork.Offer.GetById(offerId);

            if(entity.AccountId != UserId)
            {
                throw new BadRequestException("Offer could not be found");
            }

            if (entity is null)
            {
                throw new NotFoundException(nameof(Offer), offerId);
            }
            //Delete it
            await _unitOfWork.Offer.Delete(entity);
        }

        ////Update
        //public async Task Update(int id, OfferUpsertDto dto)
        //{
        //    var tempentity = await _unitOfWork.Offer.GetById(id);
        //    if (tempentity is null)
        //    {
        //        throw new NotFoundException(nameof(Offer), id);
        //    }
        //    if (dto.OfferedPrice != tempentity.OfferedPrice)
        //        tempentity.OfferedPrice = dto.OfferedPrice;
        //    await _unitOfWork.Offer.Update(tempentity);
        //}

    }
}
