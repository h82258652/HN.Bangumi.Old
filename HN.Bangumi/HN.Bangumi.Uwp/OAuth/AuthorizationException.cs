using System;
using Windows.Security.Authentication.Web;

namespace HN.Bangumi.Uwp.OAuth
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(WebAuthenticationResult authenticationResult)
        {
            if (authenticationResult == null)
            {
                throw new ArgumentNullException(nameof(authenticationResult));
            }

            Result = authenticationResult;
        }

        public WebAuthenticationResult Result
        {
            get;
        }
    }
}