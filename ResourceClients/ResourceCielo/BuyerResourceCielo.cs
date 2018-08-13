using System;
using System.Collections.Specialized;
using GatewayApiClient.DataContracts;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.ResourceClients.InterfacesCielo;
using GatewayApiClient.ResourceClients.ResourceStone;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.ResourceCielo {
    public class BuyerResourceCielo : BaseResourceCielo, IBuyerResourceCielo {
        public BuyerResourceCielo(Guid merchantId, string merchantKey, Uri hostUri, NameValueCollection customHeaders) : base(merchantId, merchantKey, "/Buyer", hostUri, customHeaders) { }

        public HttpResponse<GetBuyerData> GetBuyer(Guid buyerKey) {
            string actionName = string.Format("/{0}", buyerKey.ToString());

            HttpVerbEnum httpVerb = HttpVerbEnum.Get;

            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            return this.HttpUtility.SubmitRequest<GetBuyerData>(string.Concat(this.HostUri, this.ResourceName, actionName), httpVerb, HttpContentTypeEnum.Json, headers);
        }

        public HttpResponse<CreateBuyerResponse> CreateBuyer(CreateBuyerRequest createBuyerRequest) {
            HttpVerbEnum httpVerb = HttpVerbEnum.Post;

            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            return
                this.HttpUtility.SubmitRequest<CreateBuyerRequest, CreateBuyerResponse>(createBuyerRequest,
                    string.Concat(this.HostUri, this.ResourceName), httpVerb, HttpContentTypeEnum.Json, headers);
        }
    }
}