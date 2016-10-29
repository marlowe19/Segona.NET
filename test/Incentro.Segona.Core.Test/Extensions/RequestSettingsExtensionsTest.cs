using System;
using FluentAssertions;
using Incentro.Segona.Core.Extensions;
using NUnit.Framework;

namespace Incentro.Segona.Core.Test.Extensions
{
    [TestFixture]
    public class RequestSettingsExtensionsTest : TestBase
    {
        [Test]
        public void Should_throw_error_message_on_empty_object()
        {
            var uri = new UriHandler();
            var ex = Assert.Throws<Exception>(() => uri.CreateApiUrl(SegonaConfiguration.ApiUrl, "list", new RequestSettings()));
            Assert.That(ex.Message, Is.EqualTo("object does not have any properties"));
        }

        [Test]
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
