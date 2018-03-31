using System;
using System.Threading.Tasks;
using HN.Bangumi.Models;
using Xunit;

namespace HN.Bangumi.Services.Tests
{
    public class ProgressServiceTest
    {
        [Fact]
        public async Task TestUpdate()
        {
            try
            {
                var progressService = new ProgressService(new TestOAuthProvider());
                await progressService.Update(767951, EpStatus.Remove);
            }
            catch (Exception ex)
            {
            }
        }
    }
}