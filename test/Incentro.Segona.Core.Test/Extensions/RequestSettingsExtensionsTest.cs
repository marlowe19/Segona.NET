using System;
using FluentAssertions;
using Incentro.Segona.Core.Extensions;
using Xunit;

namespace Incentro.Segona.Core.Test.Extensions
{
    public class RequestSettingsExtensionsTest : TestBase
    {
        [Fact]
        public void Should_throw_error_message_on_empty_object()
        {
            var uri = new UriHandler();
            var ex = Assert.Throws<Exception>(() => uri.CreateApiUrl(SegonaConfiguration.ApiUrl, "list", new RequestSettings()));
            Assert.Equal("object does not have any properties", ex.Message);
        }

        [Fact]
        public void Should_Return_Settings_as_ToString()
        {
            var settings = new RequestSettings
            {
                ApiKey = "15145",
                Limit = "10",
                QueryString = "query"
            };
            var queryString = settings.ToQueryString();

            queryString.Should().BeOfType<string>();

        }
       
    }
}
