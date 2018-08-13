using System;
using System.Runtime.Serialization;
using GatewayApiClient.DataContracts.EnumTypes;

namespace GatewayApiClient.DataContracts {

    /// <summary>
    /// Dados da transação de cartão de crédito
    /// </summary>
    [DataContract(Name = "Payment", Namespace = "")]
    public class CreditCardTransactionCielo {
        /// <summary>
        /// Numero de identificação do Pedido. (Obrigatorio)
        /// </summary>
        [DataMember]
        public string MerchantOrderId { get; set; }

        [DataMember]
        public Customer Customer { get; set; }

        /// <summary>
        /// Tipo do Meio de Pagamento.
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Valor original da transação em centavos
        /// </summary>
        [DataMember]
        public long Amount { get; set; }

        /// <summary>
        /// Número de Parcelas.
        /// </summary>
        [DataMember]
        public string Installments { get; set; }

        /// <summary>
        /// Texto impresso na fatura bancaria comprador - Exclusivo para VISA/MASTER - não permite caracteres especiais - Ver Anexo
        /// </summary>
        [DataMember]
        public string SoftDescriptor { get; set; }

        /// <summary>
        /// Dados do cartão de crédito
        /// </summary>
        [DataMember]
        public CreditCardCielo CreditCard { get; set; }
    }
}
