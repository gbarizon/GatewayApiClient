using System;
using System.Collections.Specialized;
using GatewayApiClient.ResourceClients;
using GatewayApiClient.ResourceClients.InterfacesCielo;
using GatewayApiClient.ResourceClients.ResourceCielo;

namespace GatewayApiClient {

    /// <summary>
    /// Cliente para acesso aos serviços do gateway.
    /// </summary>
    public class GatewayServiceClientCielo : IGatewayServiceClientCielo {

        /// <summary>
        /// Recurso de venda
        /// </summary>
        public ISaleResourceCielo Sale { get; }
        /// <summary>
        /// Recurso de cartão de crédito
        /// </summary>
        /// 
        public ICreditCardResourceCielo CreditCard { get; }
        /// <summary>
        /// Recurso buyer
        /// </summary>
        /// 
        public IBuyerResourceCielo Buyer { get; }

        public GatewayServiceClientCielo() : this(Guid.Empty,string.Empty, null, null) { }
        public GatewayServiceClientCielo(Guid merchantId, string merchantKey) : this(merchantId, merchantKey, null, null) { }
        public GatewayServiceClientCielo(Guid merchantId, string merchantKey, Uri hostUri) : this(merchantId, merchantKey, hostUri, null) { }

        public GatewayServiceClientCielo(Guid merchanId, string merchantKey, Uri hostUri, NameValueCollection customHeaders) {

            this.Sale = new SaleResourceCielo(merchanId, merchantKey, hostUri, customHeaders);
            this.CreditCard = new CreditCardResourceStoneCielo(merchanId, merchantKey, hostUri, customHeaders);
            this.Buyer = new BuyerResourceCielo(merchanId, merchantKey, hostUri, customHeaders);
        }
    }
}
