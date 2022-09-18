using AutoMapper;
using PayCore.ProductCatalog.Application.Common.Exceptions;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Offer>> GetOffersofUser(int userId)
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
            tempEntity.Account = await _unitOfWork.Account.GetById(userId);
            tempEntity.Product = await _unitOfWork.Product.GetById(dto.ProductId);

            //Creating the offer
            await _unitOfWork.Offer.Create(tempEntity);
        }

        public async Task UpdateOffer(int userId,int offerId, OfferUpsertDto dto)
        {
            var tempentity = await _unitOfWork.Offer.GetById(userId);
            if (tempentity is null)
            {
                throw new NotFoundException(nameof(Offer), userId);
            }
            if (dto.OfferedPrice != tempentity.OfferedPrice)
                tempentity.OfferedPrice = dto.OfferedPrice;
            await _unitOfWork.Offer.Update(tempentity);
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

    }
}
