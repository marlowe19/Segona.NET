using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Segona.Net.Application;
using Segona.Net.Application.Attributes;
using Segona.Net.Application.Extensions;
using Assert = NUnit.Framework.Assert;

namespace Segona.NET.Test.Extension
{
    [TestClass]
    public class QueryStringExtensionTest
    {
        [Test]
        public void Should_throw_error_message_on_empty_object()
        {
            var uri = new UriHandler();
            var ex = Assert.Throws<Exception>(() => uri.CreateApiUrl(Settings.ApiUrl,"list", new RequestSettings()));
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
