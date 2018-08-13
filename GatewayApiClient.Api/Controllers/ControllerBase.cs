using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GatewayApiClient.Api.Controllers
{
    public class ControllerBase : ApiController
    {
        public HttpResponseMessage Response(object result)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                // Aqui devo logar o erro
                return Request.CreateResponse(HttpStatusCode.Conflict,
                    $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        public HttpResponseMessage ResponseException(Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError,
                new {errors = ex.Message, exception = ex.ToString()});
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
