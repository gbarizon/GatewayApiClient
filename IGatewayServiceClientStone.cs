using GatewayApiClient.ResourceClients.InterfacesStone;

namespace GatewayApiClient {

    /// <summary>
    /// Cliente para acesso aos serviços do gateway.
    /// </summary>
    public interface IGatewayServiceClientStone {

        /// <summary>
        /// Recurso de cartão de crédito
        /// </summary>
        ICreditCardResourceStone CreditCard { get; }

        /// <summary>
        /// Recurso buyer
        /// </summary>
        IBuyerResourceStone Buyer { get; }

        /// <summary>
        /// Recurso de venda
        /// </summary>
        ISaleResourceStone Sale { get; }
    }
}
