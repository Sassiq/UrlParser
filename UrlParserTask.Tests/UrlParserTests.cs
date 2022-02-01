using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

#pragma warning disable CA1707 //Underscores in method names

namespace UrlParserTask.Tests
{
    [TestFixture]
    public class UrlParserTests
    {
        public IConfiguration ConfigurationRoot { get; } =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("tests.json")
                .Build();

        [Test]
        public void UrlParser_WorksWithoutExceptions_Test()
        {
            Assert.DoesNotThrow(() => new UrlParser().Run());
        }

        [Test]
        public void UrlParser_WorksCorrect_Test()
        {
            new UrlParser().Run();

            using StreamReader expected = File.OpenText(this.ConfigurationRoot["expectedFilePath"]);
            using StreamReader source = File.OpenText(this.ConfigurationRoot["resultFilePath"]);

            Assert.AreEqual(expected.ReadToEnd(), source.ReadToEnd());
        }
    }
}
