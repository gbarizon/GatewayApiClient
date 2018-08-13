﻿using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GatewayApiClient.DataContracts {

    /// <summary>
    /// Resposta da consulta de pedidos
    /// </summary>
    [DataContract(Name = "QuerySaleResponse", Namespace = "")]
    public class QuerySaleResponse : BaseResponse {

        public QuerySaleResponse() {
            this.SaleDataCollection = new Collection<SaleDataStone>();
        }

        /// <summary>
        /// Lista de vendas
        /// </summary>
        [DataMember]
        public Collection<SaleDataStone> SaleDataCollection { get; set; }

        /// <summary>
        /// Indicador do total de vendas
        /// </summary>
        [DataMember]
        public int SaleDataCount { get; set; }
    }
}