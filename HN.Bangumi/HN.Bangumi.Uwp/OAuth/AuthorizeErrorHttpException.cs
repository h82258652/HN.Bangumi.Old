using System.Net;
using Windows.Security.Authentication.Web;

namespace HN.Bangumi.Uwp.OAuth
{
    public sealed class AuthorizeErrorHttpException : AuthorizationException
    {
        public AuthorizeErrorHttpException(WebAuthenticationResult authenticationResult) : base(authenticationResult)
        {
        }

        public HttpStatusCode StatusCode => (HttpStatusCode)Result.ResponseErrorDetail;
    }
}