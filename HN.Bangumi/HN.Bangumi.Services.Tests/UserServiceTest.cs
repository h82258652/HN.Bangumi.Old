using System.Threading.Tasks;
using HN.Bangumi.Models;
using Xunit;

namespace HN.Bangumi.Services.Tests
{
    public class UserServiceTest
    {
        [Fact]
        public async Task TestGetByUsername()
        {
            var userService = new UserService(new TestOAuthProvider());
            var user = await userService.Get("h82258652");
            Assert.Equal("h82258652", user.Username);
        }

        [Fact]
        public async Task TestGetByUid()
        {
            var userService = new UserService(new TestOAuthProvider());
            var user = await userService.Get(200242);
            Assert.Equal(200242, user.Id);
        }

        [Fact]
        public async Task TestGetProgressByUsername()
        {
            var userService = new UserService(new TestOAuthProvider());
            var progress = await userService.GetProgress("h82258652");
            Assert.NotNull(progress);
        }

        [Fact]
        public async Task TestGetProgressByUid()
        {
            var userService = new UserService(new TestOAuthProvider());
            var progress = await userService.GetProgress(200242);
            Assert.NotNull(progress);
        }

        [Fact]
        public async Task TestGetCollectionByUsername()
        {
            var userService = new UserService(new TestOAuthProvider());
            var userCollections = await userService.GetCollection("h82258652", CollectionCategory.Watching);
            Assert.NotEmpty(userCollections);
        }

        [Fact]
        public async Task TestGetCollectionByUid()
        {
            var userService = new UserService(new TestOAuthProvider());
            var userCollections = await userService.GetCollection(200242, CollectionCategory.AllWatching);
            Assert.NotEmpty(userCollections);
        }

        [Fact]
        public async Task GetSubjectCollectionInfo()
        {
            var userService = new UserService(new TestOAuthProvider());
            var subjectCollectionInfo = await userService.GetSubjectCollectionInfo(218708);
            Assert.NotNull(subjectCollectionInfo);
        }
    }
}