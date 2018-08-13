using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;

namespace GatewayApiClient.Api.Controllers
{
    [RoutePrefix("api/gateway")]
    public class CreditCardApiController : ControllerBase
    {
        #region fields

        private Uri _endpoint = null; 
        private Guid _merchantIdCielo;
        private string _merchantKeyCielo;
        private Guid _merchantKeyStone;
        private bool _useAntifraude;

        #endregion Fields

        public CreditCardApiController()
        {
            //Recuperar Informacao do cliente base de dados (A fazer)
            this._merchantIdCielo = Guid.Parse("12b78dd2-7128-4107-b655-f6ca7ec4eb04");
            this._merchantKeyCielo = "LGOORJZONXASVXOBEBFUYPXVNILAGMDKPWZEBXLJ";
            this._useAntifraude = false;
            this._merchantKeyStone = Guid.Parse(_useAntifraude
                ? "7b379c45-57d6-4508-ae56-29bb0b3c9741"
                : "f2a1f485-cfd4-49f5-8862-0ebc438ae923");
        }

        [Route("PassarCartaoVisa")]
        [HttpPost]
        public HttpResponseMessage PassarCartaoVisa(CreditCardTransactionStone transaction)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            var resultadoVerficarCartaoAntiFraude = string.Empty;

            //Clinte Usa AntiFraude 
            if (VarificarClienteUsaAntiFraude(false))
            {
                resultadoVerficarCartaoAntiFraude = VerificarCartaoAntiFraude();
            }

            if (string.Compare(resultadoVerficarCartaoAntiFraude, "APA", StringComparison.OrdinalIgnoreCase) > 0)
            {
                //Retornar antifraude mensagem
            }

            //Deveria vir do banco de dados
            this._endpoint = new Uri("https://transaction.stone.com.br");
            var saleRequest = CreateStoneSaleRequest(transaction);
            var serviceClient = new GatewayServiceClientStone(_merchantKeyStone, _endpoint, null);
            return Response(serviceClient.Sale.Create(saleRequest));
        }

        [Route("PassarCartaoMaster")]
        [HttpPost]
        public HttpResponseMessage PassarCartaoMaster(CreditCardTransactionCielo transaction)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            var resultadoVerficarCartaoAntiFraude = string.Empty;

            //Clinte Usa AntiFraude 
            if (VarificarClienteUsaAntiFraude(false))
            {
                resultadoVerficarCartaoAntiFraude = VerificarCartaoAntiFraude();
            }

            if (string.Compare(resultadoVerficarCartaoAntiFraude, "APA", StringComparison.OrdinalIgnoreCase) > 0)
            {
                //Retornar antifraude mensagem
            }

            //Deveria vir do banco de dados
            this._endpoint = new Uri("https://apisandbox.cieloecommerce.cielo.com.br");

            return Response(new GatewayServiceClientCielo(_merchantIdCielo, _merchantKeyCielo, _endpoint, null));
        }

        private CreateSaleRequestStone CreateStoneSaleRequest(CreditCardTransactionStone transaction)
        {
            // Cria requisição.
            var createSaleRequest = new CreateSaleRequestStone()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionStoneCollection =
                    new Collection<CreditCardTransactionStone>(new CreditCardTransactionStone[] { transaction }),
                Order = new Order()
                {
                    OrderReference = "NumeroDoPedido"
                }
            };

            return createSaleRequest;
        }

        //Task Colocar mock da api de verificacao.
        private string VerificarCartaoAntiFraude()
        {
            //Usar API para verificar Cartao

            //MOCK retorno
            return "APA";
        }

        private bool VarificarClienteUsaAntiFraude(bool mockParametro)
        {
            //(Verificar no banco de dados)
            if (mockParametro)
                return true;

            return false;
        }
    }
}