using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarn
{
    class OAuthToken
    {
        public String AccessToken;

        public String RefreshToken;

        public OAuthToken(string accessToken = null, string refreshToken = null )
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

    }
}
