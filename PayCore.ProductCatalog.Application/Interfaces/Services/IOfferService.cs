using PayCore.ProducCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Services
{
    public interface IOfferService
    {
       
        //Offer on product
        Task OfferOnProduct(int userId,OfferUpsertDto dto);

        //Withdraw the offer which user made
        Task WithDrawOffer(int userId, int offerId);

        //Updating the offer which user made
        Task UpdateOffer(int userID,int id, OfferUpsertDto dto);

        //Get offers which has id of user
        Task<List<OfferViewDto>> GetOffersofUser(int userId);

        //Get offers by id of offer
        //Task<OfferViewDto> GetOffersByID(int id);
    }
}
