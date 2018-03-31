using System.Threading.Tasks;

namespace HN.Bangumi.OAuth
{
    public interface IOAuthProvider
    {
        Task<string> GetAccessToken();
    }
}