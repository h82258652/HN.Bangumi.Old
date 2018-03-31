using System.Threading.Tasks;
using Xunit;

namespace HN.Bangumi.Services.Tests
{
    public class UserServiceTest
    {
        [Fact]
        public async Task TestGetByUsername()
        {
            var userService = new UserService();
            var user = await userService.Get("h82258652");
            Assert.Equal("h82258652", user.Username);
        }

        [Fact]
        public async Task TestGetByUid()
        {
            var userService = new UserService();
            var user = await userService.Get(200242);
            Assert.Equal(200242, user.Id);
        }
    }
}