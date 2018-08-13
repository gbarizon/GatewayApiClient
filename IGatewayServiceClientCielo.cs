using GatewayApiClient.ResourceClients.InterfacesCielo;

namespace GatewayApiClient {

    /// <summary>
    /// Cliente para acesso aos serviços do gateway.
    /// </summary>
    public interface IGatewayServiceClientCielo {

        /// <summary>
        /// Recurso de cartão de crédito
        /// </summary>
        ICreditCardResourceCielo CreditCard { get; }

        /// <summary>
        /// Recurso buyer
        /// </summary>
        IBuyerResourceCielo Buyer { get; }

        /// <summary>
        /// Recurso de venda
        /// </summary>
        ISaleResourceCielo Sale { get; }
    }
}
