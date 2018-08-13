using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GatewayApiClient.DataContracts;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.ResourceClients.InterfacesStone;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.ResourceStone {

    public class SaleResourceStoneStone : BaseResourceStone, ISaleResourceStone {

        public SaleResourceStoneStone(Guid merchantKey, Uri hostUri, NameValueCollection customHeaders) : base(merchantKey, "/Sale", hostUri, customHeaders) { }

        #region Create

        /// <summary>
        /// Cria uma venda, contendo transações de boleto e/ou cartão de crédito
        /// </summary>
        /// <param name="createSaleRequestStone">Dados da venda</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(CreateSaleRequestStone createSaleRequestStone) {

            // Configura MerchantKey e o header
            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            // Envia requisição
            return this.HttpUtility.SubmitRequest<CreateSaleRequestStone, CreateSaleResponse>(createSaleRequestStone,
                string.Concat(this.HostUri, this.ResourceName), HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);
        }

        /// <summary>
        /// Cria uma venda com uma coleção de transações de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionCollection">Coleção de transações de cartão de crédito</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(Collection<CreditCardTransactionStone> creditCardTransactionCollection, string orderReference) {

            CreateSaleRequestStone createSaleRequestStone =
                new CreateSaleRequestStone
                {
                    CreditCardTransactionStoneCollection = creditCardTransactionCollection,
                    Options = new SaleOptions() {IsAntiFraudEnabled = false}
                };
            // Se não for informado o comprador nem o carrinho de compras não será possível utilizar o serviço de anti fraude.
            if (string.IsNullOrWhiteSpace(orderReference) == false) {
                createSaleRequestStone.Order = new Order() {
                    OrderReference = orderReference
                };
            }

            return this.Create(createSaleRequestStone);
        }

        /// <summary>
        /// Cria uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransaction">Dados da transação de cartão de crédito</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(CreditCardTransactionStone creditCardTransaction, string orderReference) {

            Collection<CreditCardTransactionStone> creditCardTransactionCollection = new Collection<CreditCardTransactionStone>();
            creditCardTransactionCollection.Add(creditCardTransaction);

            return this.Create(creditCardTransactionCollection, orderReference);
        }

        /// <summary>
        /// Cria uma venda com uma coleção de transações de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionCollection">Coleção de transações de cartão de crédito</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(Collection<CreditCardTransactionStone> creditCardTransactionCollection) {

            return this.Create(creditCardTransactionCollection, null);
        }

        /// <summary>
        /// Cria uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransaction">Dados da transação de cartão de crédito</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(CreditCardTransactionStone creditCardTransaction) {

            return this.Create(creditCardTransaction, null);
        }
        
        #endregion

        #region Manage

        /// <summary>
        /// Gerencia uam venda
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="manageSaleRequest">Dados da venda</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, ManageSaleRequest manageSaleRequest) {

            // Configura o action que será utilizado
            string actionName = manageOperation.ToString();

            // Configura MerchantKey e o header
            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            // Envia requisição
            return this.HttpUtility.SubmitRequest<ManageSaleRequest, ManageSaleResponse>(manageSaleRequest,
                string.Concat(this.HostUri, this.ResourceName, "/", actionName), HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);
        }

        /// <summary>
        /// Gerencia uma venda
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey) {

            ManageSaleRequest manageSaleRequest = new ManageSaleRequest();
            manageSaleRequest.OrderKey = orderKey;

            return this.Manage(manageOperation, manageSaleRequest);
        }


        /// <summary>
        /// Gerencia uma coleção de transações de cartão de crédito.
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="manageCreditCardTransactionCollection">Coleção de transações que serão gerenciadas</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey, Collection<ManageCreditCardTransaction> manageCreditCardTransactionCollection) {

            ManageSaleRequest manageSaleRequest = new ManageSaleRequest();
            manageSaleRequest.OrderKey = orderKey;
            manageSaleRequest.CreditCardTransactionCollection = manageCreditCardTransactionCollection;

            return this.Manage(manageOperation, manageSaleRequest);
        }

        /// <summary>
        /// Gerencia uma transação de cartão de crédito específica
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="manageCreditCardTransaction">Dados da transação que será gerenciada</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey, ManageCreditCardTransaction manageCreditCardTransaction) {

            Collection<ManageCreditCardTransaction> manageCreditCardTransactionCollection = new Collection<ManageCreditCardTransaction>();
            manageCreditCardTransactionCollection.Add(manageCreditCardTransaction);

            return this.Manage(manageOperation, orderKey, manageCreditCardTransactionCollection);
        }

        #endregion

        #region Retry

        public HttpResponse<RetrySaleResponse> Retry(RetrySaleRequest retrySaleRequest) {

            // Configura MerchantKey e o header
            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            // Envia requisição
            return this.HttpUtility.SubmitRequest<RetrySaleRequest, RetrySaleResponse>(retrySaleRequest,
                string.Concat(this.HostUri, this.ResourceName, "/Retry"), HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);
        }

        public HttpResponse<RetrySaleResponse> Retry(Guid orderKey) {

            RetrySaleRequest retrySaleRequest = new RetrySaleRequest();
            retrySaleRequest.OrderKey = orderKey;

            return this.Retry(retrySaleRequest);
        }

        public HttpResponse<RetrySaleResponse> Retry(Guid orderKey, Collection<RetrySaleCreditCardTransaction> retrySaleCreditCardTransactionCollection) {

            RetrySaleRequest retrySaleRequest = new RetrySaleRequest();
            retrySaleRequest.OrderKey = orderKey;
            retrySaleRequest.RetrySaleCreditCardTransactionCollection = retrySaleCreditCardTransactionCollection;

            return this.Retry(retrySaleRequest);
        }

        public HttpResponse<RetrySaleResponse> Retry(Guid orderKey, RetrySaleCreditCardTransaction retrySaleCreditCardTransaction) {

            Collection<RetrySaleCreditCardTransaction> retrySaleCreditCardTransactionCollection = new Collection<RetrySaleCreditCardTransaction>();
            retrySaleCreditCardTransactionCollection.Add(retrySaleCreditCardTransaction);

            return this.Retry(orderKey, retrySaleCreditCardTransactionCollection);
        }

        #endregion

        #region Query

        /// <summary>
        /// Consulta uma venda
        /// </summary>
        /// <param name="orderKey">Chave da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryOrder(Guid orderKey) {
            return this.QueryImplementation("OrderKey", orderKey.ToString());
        }

        /// <summary>
        /// Consulta uma venda
        /// </summary>
        /// <param name="orderReference">Identificador do pedido no sistema da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryOrder(string orderReference) {
            return this.QueryImplementation("OrderReference", orderReference);
        }

        /// <summary>
        /// Consulta uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionKey">Chave da transação de cartão de crédito</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryCreditCardTransaction(Guid creditCardTransactionKey) {
            return this.QueryImplementation("CreditCardTransactionKey", creditCardTransactionKey.ToString());
        }

        /// <summary>
        /// Consulta uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionReference">Identificador da transação no sistema da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryCreditCardTransaction(string creditCardTransactionReference) {
            return this.QueryImplementation("CreditCardTransactionReference", creditCardTransactionReference);
        }

        /// <summary>
        /// Consulta uma transação de boleto
        /// </summary>
        /// <param name="boletoTransactionKey">Chave da transação de boleto</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryBoletoTransaction(Guid boletoTransactionKey) {
            return this.QueryImplementation("BoletoTransactionKey", boletoTransactionKey.ToString());
        }

        /// <summary>
        /// Consulta uma transação de boleto
        /// </summary>
        /// <param name="boletoTransactionReference">Identificador da transação no sistema da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryBoletoTransaction(string boletoTransactionReference) {
            return this.QueryImplementation("BoletoTransactionReference", boletoTransactionReference);
        }

        /// <summary>
        /// Implementação da chamada do método Query
        /// </summary>
        /// <param name="identifierName">Nome do identificador utilizado para realizar a consulta</param>
        /// <param name="value">Identificador utilizado para realizar a consulta</param>
        /// <returns></returns>
        private HttpResponse<QuerySaleResponse> QueryImplementation(string identifierName, string value) {

            string actionName = string.Format("/Query/{0}={1}", identifierName, value);

            HttpVerbEnum httpVerb = HttpVerbEnum.Get;

            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            return this.HttpUtility.SubmitRequest<QuerySaleResponse>(string.Concat(this.HostUri, this.ResourceName, actionName), httpVerb, HttpContentTypeEnum.Json, headers);
        }

        #endregion
    }
}
