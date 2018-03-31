using Windows.Security.Authentication.Web;

namespace HN.Bangumi.Uwp.OAuth
{
    public sealed class UserCancelAuthorizeException : AuthorizationException
    {
        public UserCancelAuthorizeException(WebAuthenticationResult authenticationResult) : base(authenticationResult)
        {
        }
    }
}