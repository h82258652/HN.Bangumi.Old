using System.Threading.Tasks;
using HN.Bangumi.OAuth;

namespace HN.Bangumi.Services.Tests
{
    public class TestOAuthProvider : IOAuthProvider
    {
        public Task<string> GetAccessToken()
        {
            return Task.FromResult("ff27e55a664c823219cd54a40d4e6d6e99385da1");
        }
    }
}