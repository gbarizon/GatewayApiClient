using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GatewayApiClient.DataContracts.EnumTypes;

namespace GatewayApiClient.DataContracts
{
    /// <summary>
    /// Dados da pessoa
    /// </summary>
    [DataContract(Name = "Customer", Namespace = "")]
    public class Customer
    {
        /// <summary>
        /// Comprador crédito simples
        /// </summary>
        [DataMember]
        public string Name { get; set; }

    }
}
