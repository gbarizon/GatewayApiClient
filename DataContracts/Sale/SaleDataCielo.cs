using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GatewayApiClient.DataContracts {

    /// <summary>
    /// Entidade que representa a venda
    /// </summary>
    [DataContract(Name = "Sale", Namespace = "")]
    public class SaleDataCielo {

        /// <summary>
        /// Lista de transações de cartão de crédito
        /// </summary>
        [DataMember]
        public Collection<CreditCardTransactionData> CreditCardTransactionDataCollection { get; set; }
    }
}