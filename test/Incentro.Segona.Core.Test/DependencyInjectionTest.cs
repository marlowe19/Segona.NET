using Xunit;

namespace Incentro.Segona.Core.Test
{
    public class DependencyInjectionTest : TestBase
    {
        [Fact]
        public void GetClientAndOptios()
        {
            var segonaClient = (SegonaClient)Provider.GetService(typeof(SegonaClient));
            var configuration = (SegonaBuilderConfiguration)Provider.GetService(typeof(SegonaBuilderConfiguration));
            Assert.NotNull(segonaClient);
            Assert.NotNull(configuration);
        }
    }
}
