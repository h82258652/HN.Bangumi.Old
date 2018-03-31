using System.Threading.Tasks;
using HN.Bangumi.Models;
using Xunit;

namespace HN.Bangumi.Services.Tests
{
    public class SubjectServiceTest
    {
        [Fact]
        public async Task TestGetSmall()
        {
            var subjectService = new SubjectService();
            var subject = await subjectService.Get(12, ResponseGroup.Small);
            Assert.Equal(12, subject.Id);
        }

        [Fact]
        public async Task TestGetMedium()
        {
            var subjectService = new SubjectService();
            var subject = await subjectService.Get(12, ResponseGroup.Medium);
            Assert.Equal(12, subject.Id);
        }

        [Fact]
        public async Task TestGetLarge()
        {
            var subjectService = new SubjectService();
            var subject = await subjectService.Get(12, ResponseGroup.Large);
            Assert.Equal(12, subject.Id);
        }
    }
}