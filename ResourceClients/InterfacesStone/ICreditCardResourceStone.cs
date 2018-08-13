using System;
using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.InterfacesStone {

    public interface ICreditCardResourceStone : IBaseResourceStone {

        HttpResponse<GetInstantBuyDataResponse> GetInstantBuyData(Guid instantBuyKey);

        HttpResponse<GetInstantBuyDataResponse> GetInstantBuyDataWithBuyerKey(Guid buyerKey);

        HttpResponse<GetInstantBuyDataResponse> GetCreditCard(Guid instantBuyKey);

        HttpResponse<GetInstantBuyDataResponse> GetCreditCardWithBuyerKey(Guid buyerKey);

        HttpResponse<CreateInstantBuyDataResponse> CreateCreditCard(
            CreateInstantBuyDataRequest createInstantBuyDataRequest);

        HttpResponse<DeleteInstantBuyDataResponse> DeleteCreditCard(Guid instantBuyKey);

        HttpResponse<UpdateInstantBuyDataResponse> UpdateCreditCard(
            UpdateInstantBuyDataRequest updateInstantBuyDataRequest, Guid instantBuyKey);
    }
}
