using System;
using System.Collections.Specialized;
using GatewayApiClient.ResourceClients.InterfacesStone;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.ResourceStone {

    public abstract class BaseResourceStone : IBaseResourceStone {
        public string ResourceName { get; }

        public Guid MerchantKey { get; set; }
        protected string HostUri { get; }

        private readonly NameValueCollection _customHeader = null;

        internal HttpUtility HttpUtility { get; set; }

        protected BaseResourceStone(Guid merchantKey, string resourceName, Uri hostUri, NameValueCollection customHeaders) {

            if (merchantKey == Guid.Empty) {
                merchantKey = ConfigurationUtility.GetConfigurationKey("MerchantKeyStone");
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

            return ConfigurationUtility.GetConfigurationString("HostUriStone");
        }

        protected NameValueCollection GetHeaders() {

            NameValueCollection headers = new NameValueCollection();

            if (this._customHeader != null) {
                foreach (string headerName in this._customHeader) {
                    headers.Add(headerName, this._customHeader[headerName]);
                }
            }

            return headers;
        }
    }
}
