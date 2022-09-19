﻿using AutoMapper;
using PayCore.ProducCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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

        public async Task ApproveOffer(int id, int userID)
        {
            //It fetches offers to user
            var offers = await _unitOfWork.Offer.GetOfferstoUser(userID);

            //It selects the offer to be approved
            var offer = offers.Where(x=>x.Id == id).FirstOrDefault();

            if (offer is null)
            {
                throw new NotFoundException(nameof(Offer), id);
            }

            //offer is approved
            offer.IsApproved = true;
            await _unitOfWork.Offer.Update(offer);

        }

       

        public async Task DisapproveOffer(int id, int userId)
        {
            //It fetches offers to user
            var offers = await _unitOfWork.Offer.GetOfferstoUser(userId);

            //It selects the offer to be approved
            var offer = offers.Where(x => x.Id == id).FirstOrDefault();

            if(offer is null)
            {
                throw new NotFoundException(nameof(Offer), id);
            }
            //offer is approved
            offer.IsApproved = false;

            //update
            await _unitOfWork.Offer.Update(offer);
        }


        //Get Offers of user made it
        public async Task<List<OfferViewDto>> GetOffersofUser(int userId)
        {
            //Fetch all the offers with id of user
            var listOffer = await _unitOfWork.Offer.GetOfferOfUser(userId);

            //İnitiating a list for offer view to be inserted
            var result = new List<OfferViewDto>();

            //Looping through offers that is fetched from database 
            using (var sequenceEnum = listOffer.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    //Mapping to view model 
                    //Automapper is not preferred to be used here. Since this kind of mapping needs to be more distinct
                    var offerView = new OfferViewDto()
                    {
                       Id = sequenceEnum.Current.Id,
                       OfferedPrice = sequenceEnum.Current.OfferedPrice,
                       IsApproved = sequenceEnum.Current.IsApproved,
                       Product =  new ProductViewDto() { 
                                Id = sequenceEnum.Current.Product.Id,
                                ProductName = sequenceEnum.Current.Product.ProductName,
                                Description = sequenceEnum.Current.Product.Description,
                                Price = sequenceEnum.Current.Product.Price,
                                CategoryName = sequenceEnum.Current.Product.Category.CategoryName,
                                ColorName = sequenceEnum.Current.Product.Color.ColorName,
                                BrandName = sequenceEnum.Current.Product.Brand.BrandName,
                                    }
                    };
                    result.Add(offerView);
                }
            }
            return result;
        }


        //Get offers has been made to user
        public async Task<IList<OfferViewDto>> GetOffersToUser(int userId)
        {
            //Fetch all the offers with id of user
            var listOffer = await _unitOfWork.Offer.GetOfferstoUser(userId);

            //İnitiating a list for offer view to be inserted
            var result = new List<OfferViewDto>();

            //Looping through offers that is fetched from database 
            using (var sequenceEnum = listOffer.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    //Mapping to view model 
                    //Automapper is not preferred to be used here. Since this kind of mapping needs to be more distinct
                    var offerView = new OfferViewDto()
                    {
                        Id = sequenceEnum.Current.Id,
                        OfferedPrice = sequenceEnum.Current.OfferedPrice,
                        IsApproved = sequenceEnum.Current.IsApproved,
                        Product = new ProductViewDto()
                        {
                            Id = sequenceEnum.Current.Product.Id,
                            ProductName = sequenceEnum.Current.Product.ProductName,
                            Description = sequenceEnum.Current.Product.Description,
                            Price = sequenceEnum.Current.Product.Price,
                            CategoryName = sequenceEnum.Current.Product.Category.CategoryName,
                            ColorName = sequenceEnum.Current.Product.Color.ColorName,
                            BrandName = sequenceEnum.Current.Product.Brand.BrandName,
                            IsSold = sequenceEnum.Current.Product.IsSold,
                        }
                    };
                    result.Add(offerView);
                }
            }
            return result;
        }



        //Insert
        public async Task OfferOnProduct(int userId,OfferUpsertDto dto)
        {
            //To check if product is offerable
            var product = await _unitOfWork.Product.GetById(dto.ProductId);
            if (product.IsOfferable == false || product.Account.Id == userId)
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



        //Update
        public async Task UpdateOffer(int userId,int offerId, OfferUpsertDto dto)
        {
            var tempentity = await _unitOfWork.Offer.GetById(userId);
            if (tempentity is null)
            {
                throw new NotFoundException(nameof(Offer), userId);
            }
            //Offered price is updated
            if (dto.OfferedPrice != tempentity.OfferedPrice)
                tempentity.OfferedPrice = dto.OfferedPrice;
            await _unitOfWork.Offer.Update(tempentity);
        }



        //Remove
        public async Task WithDrawOffer(int UserId, int offerId)
        {
            //Fetch the offer
            var entity = await _unitOfWork.Offer.GetById(offerId);

            //If user tries to use offer doesnt to belong to him/her
            if(entity.Account.Id != UserId)
            {
                throw new BadRequestException("Offer could not be found");
            }
            //If it is null throw exception
            if (entity is null)
            {
                throw new NotFoundException(nameof(Offer), offerId);
            }
            //Delete it
            await _unitOfWork.Offer.Delete(entity);
        }


        public async Task BuyProductWithoutOffer(int productId, int userId)
        {
            var entity = await _unitOfWork.Product.GetById(productId);

            if(entity.Account.Id == userId)
            {
                throw new BadRequestException("Product belongs to user");
            }

            if(entity is null)
            {
                throw new NotFoundException(nameof(Product), productId);
            }

            entity.IsSold = true;
            await _unitOfWork.Product.Update(entity);
        }
    }
}
