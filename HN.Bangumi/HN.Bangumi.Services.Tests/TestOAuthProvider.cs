using System.Threading.Tasks;
using HN.Bangumi.OAuth;

namespace HN.Bangumi.Services.Tests
{
    public class TestOAuthProvider : IOAuthProvider
    {
        public Task<string> GetAccessToken()
        {
            return Task.FromResult("0210cf4e5bd7b5f9d15d8da2cf0c54236e4776ca");
        }
    }
}