using System.Security.AccessControl;

namespace Yarn
{
    public class YarnLib
    {
        private readonly string _clientId;
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public YarnLib(string clientId)
        {
            this._clientId = clientId;
        }

        public string RetrieveAccessToken()
        {
            return "";
        }

        public string AuthUrl(string scope)
        {
            var url = "https://www.reddit.com/api/v1/authorize?client_id=" + _clientId + "&response_type=code"
                      + "&state=" + _clientId + ":" + "" 
                      + "&redirect_uri=yarr://redirect";

            return url;
        }
        
    }



}