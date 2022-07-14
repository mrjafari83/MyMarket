using Market.EndPoint;
using Xunit;

namespace Market_Integration_Tests
{
    public class Excel_Integration_Tests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private HttpClient _client;

        public Excel_Integration_Tests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateExcelTest()
        {
            var response = await _client.GetAsync("/Admin/Product/CreateExcelConfirmed");
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("پنل مدیریت", responseString);
            Assert.Contains("محصولات", responseString);
        }
    }
}
