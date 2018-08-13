using System;
using System.Runtime.Serialization;
using GatewayApiClient.DataContracts.EnumTypes;

namespace GatewayApiClient.DataContracts {

    [DataContract(Name = "CreditCard", Namespace = "")]
    public class CreditCardCielo {
        
        /// <summary>
        /// Número do cartão de crédito
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Titular do cartão
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Holder { get; set; }

        /// <summary>
        /// Data de expiração do cartão de crédito ex: 12/2030
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int ExpirationDate { get; set; }

        /// <summary>
        /// Código de segurança - CVV
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string SecurityCode { get; set; }
      

        #region CreditCardBrand

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        [DataMember(Name = "CreditCardBrand", EmitDefaultValue = false)]
        private string BrandField {
            get {
                if (this.Brand == null) { return null; }
                return this.Brand.Value.ToString();
            }
            set {
                if (value == null) {
                    this.Brand = null;
                }
                else {
                    this.Brand = (CreditCardBrandEnum)Enum.Parse(typeof(CreditCardBrandEnum), value);
                }
            }
        }

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        public CreditCardBrandEnum? Brand { get; set; }

        #endregion

        ///// <summary>
        ///// Endereço de cobrança
        ///// </summary>
        //[DataMember(EmitDefaultValue = false)]
        //public BillingAddress BillingAddress { get; set; }
    }
}