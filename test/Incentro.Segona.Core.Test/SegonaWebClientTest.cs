using System.Threading.Tasks;
using Xunit;

namespace Incentro.Segona.Core.Test
{
    public class SegonaWebClientTest
    {
        [Fact]
        public async Task QuickTest()
        {
            var key = "801382cd9832759ec2b1f960b48412d1";
            var segonaClient = new SegonaWebClient();
            var assetList = await segonaClient.GetAllAssetsAsync(key);
            Assert.NotNull(assetList);
        }
    }
}
