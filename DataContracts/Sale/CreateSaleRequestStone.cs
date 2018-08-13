using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GatewayApiClient.DataContracts {

    /// <summary>
    /// Criação de uma nova venda
    /// </summary>
    [DataContract(Name = "CreateSaleRequestStone", Namespace = "")]
    public class CreateSaleRequestStone {

        public CreateSaleRequestStone() {
            Options = new SaleOptions();
        }

        /// <summary>
        /// Lista de transações de cartão de crédito
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Collection<CreditCardTransactionStone> CreditCardTransactionStoneCollection { get; set; }

        /// <summary>
        /// Dados do pedido
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Order Order { get; set; }

        /// <summary>
        /// Dados do comprador
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Buyer Buyer { get; set; }
        
        /// <summary>
        /// Informações opcionais para a criação da venda
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public SaleOptions Options { get; set; }

        /// <summary>
        /// Dados da loja
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Merchant Merchant { get; set; }

        /// <summary>
        /// Informações complementares da requisição
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public RequestData RequestData { get; set; }
    }
}