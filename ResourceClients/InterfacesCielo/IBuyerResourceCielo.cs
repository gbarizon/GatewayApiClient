using System;
using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.InterfacesCielo {
    public interface IBuyerResourceCielo {
        HttpResponse<GetBuyerData> GetBuyer(Guid buyerKey);

        HttpResponse<CreateBuyerResponse> CreateBuyer(CreateBuyerRequest createBuyerRequest);
    }
}