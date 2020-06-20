using System.Security.AccessControl;

namespace Yarn
{
    public class YarnLib
    {
        private string _clientId;
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

        public string AuthURL(string scope)
        {
            string url = "https://www.reddit.com/api/v1/authorize?client_id=" + _clientId + "&response_type=code"
                + "&state=" + _clientId + ":" + "" 
                + "&redirect_uri=http://localhost:8080" + "/YARR/oauthRedirect&duration=permanent" + "&scope=" + scope;

            return url;
        }
        
    }



}