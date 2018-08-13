using System;

namespace GatewayApiClient.ResourceClients.InterfacesCielo {

    public interface IBaseResourceCielo {

        /// <summary>
        /// Chave Publica para Autenticação Dupla na Cielo.
        /// </summary>
        string MerchantKey { get; set; }

        /// <summary>
        /// Identificador do Request, utilizado quando o lojista usa diferentes servidores para cada GET/POST/PUT.
        /// </summary>
        Guid MerchantId { get; set; }

        /// <summary>
        /// Nome do recurso que será acessado.
        /// </summary>
        string ResourceName { get; }
    }
}
