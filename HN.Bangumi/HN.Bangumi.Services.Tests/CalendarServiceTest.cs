using System.Threading.Tasks;
using Xunit;

namespace HN.Bangumi.Services.Tests
{
    public class CalendarServiceTest
    {
        [Fact]
        public async Task TestGet()
        {
            var calendarService = new CalendarService();
            var calendar = await calendarService.GetAsync();
            Assert.Equal(7, calendar.Length);
        }
    }
}