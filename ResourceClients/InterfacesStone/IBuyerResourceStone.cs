using System;
using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.InterfacesStone
{
    public interface IBuyerResourceStone {
        HttpResponse<GetBuyerData> GetBuyer(Guid buyerKey);

        HttpResponse<CreateBuyerResponse> CreateBuyer(CreateBuyerRequest createBuyerRequest);
    }
}