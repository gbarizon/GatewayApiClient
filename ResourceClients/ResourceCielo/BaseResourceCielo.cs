using System;
using System.Collections.Specialized;
using GatewayApiClient.ResourceClients.InterfacesCielo;
using GatewayApiClient.ResourceClients.InterfacesStone;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.ResourceCielo {

    public abstract class BaseResourceCielo : IBaseResourceCielo {
        public Guid MerchantId { get; set; }
        public string ResourceName { get; }

        public string MerchantKey { get; set; }
        protected string HostUri { get; }

        private readonly NameValueCollection _customHeader = null;

        internal HttpUtility HttpUtility { get; set; }

        protected BaseResourceCielo(Guid merchantId, string merchantKey, string resourceName, Uri hostUri, NameValueCollection customHeaders) {

            if (merchantId == Guid.Empty || merchantKey == string.Empty)
            {
                merchantId = ConfigurationUtility.GetConfigurationKey("MerchantIdCielo");
                merchantKey = ConfigurationUtility.GetConfigurationId("MerchantKeyCielo");
            }

            this.HttpUtility = new HttpUtility();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            this.MerchantKey = merchantKey;
            if (hostUri != null) {
                this.HostUri = hostUri.ToString();
                this.HostUri = this.HostUri.Remove(this.HostUri.Length - 1);
            }
            else {
                this.HostUri = this.GetServiceUri();
            }
            this.ResourceName = resourceName;

            this._customHeader = customHeaders;
        }

        private string GetServiceUri() {

            return ConfigurationUtility.GetConfigurationString("HostUri");
        }

        protected NameValueCollection GetHeaders() {

            var headers = new NameValueCollection();

            if (this._customHeader != null) {
                foreach (string headerName in this._customHeader) {
                    headers.Add(headerName, this._customHeader[headerName]);
                }
            }

            return headers;
        }
    }
}
