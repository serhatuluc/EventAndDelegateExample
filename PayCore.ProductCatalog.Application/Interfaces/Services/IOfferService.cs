using PayCore.ProducCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Dto_Validator;
using System.Collections.Generic;
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
        Task UpdateOffer(int userID,int offerId, OfferUpsertDto dto);

        //Get offers which has id of user
        Task<List<OfferViewDto>> GetOffersofUser(int userId);

        //Disapprove offer
        Task DisapproveOffer(int offerId,int userId);

        //Approve offer
        Task ApproveOffer(int offerId, int userId);

        //Get offers has been made to product belongs to user
        Task<IList<OfferViewDto>> GetOffersToUser(int userId);

        //Buy without offering
        Task BuyProductWithoutOffer(int offerId, int userId);


    }
}
