using System;
using System.Collections.Specialized;
using GatewayApiClient.ResourceClients;
using GatewayApiClient.ResourceClients.InterfacesStone;
using GatewayApiClient.ResourceClients.ResourceStone;

namespace GatewayApiClient {

    /// <summary>
    /// Cliente para acesso aos serviços do gateway.
    /// </summary>
    public class GatewayServiceClientStone : IGatewayServiceClientStone {

        /// <summary>
        /// Recurso de venda
        /// </summary>
        public ISaleResourceStone Sale { get; }
        /// <summary>
        /// Recurso de cartão de crédito
        /// </summary>
        /// 
        public ICreditCardResourceStone CreditCard { get; }
        /// <summary>
        /// Recurso buyer
        /// </summary>
        /// 
        public IBuyerResourceStone Buyer { get; }

        public GatewayServiceClientStone() : this(Guid.Empty, null, null) { }
        public GatewayServiceClientStone(Guid merchantKey) : this(merchantKey, null, null) { }
        public GatewayServiceClientStone(Guid merchantKey, Uri hostUri) : this(merchantKey, hostUri, null) { }

        public GatewayServiceClientStone(Guid merchantKey, Uri hostUri, NameValueCollection customHeaders) {

            this.Sale = new SaleResourceStoneStone(merchantKey, hostUri, customHeaders);
            this.CreditCard = new CreditCardResourceStoneStone(merchantKey, hostUri, customHeaders);
            this.Buyer = new BuyerResourceStone(merchantKey, hostUri, customHeaders);
        }
    }
}
