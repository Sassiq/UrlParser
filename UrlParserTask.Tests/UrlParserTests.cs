using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

#pragma warning disable CA1707 //Underscores in method names

namespace UrlParserTask.Tests
{
    [TestFixture]
    public class UrlParserTests
    {
        [Test]
        public void UrlParser_WorksWithoutExceptions_Test()
        {
            Assert.DoesNotThrow(() => new UrlParser().Run());
        }

        [Test]
        public void UrlParser_WorksCorrect_Test()
        {
            new UrlParser().Run();

            using StreamReader expected = File.OpenText("expected.xml");
            using StreamReader source = File.OpenText("output.xml");

            Assert.AreEqual(expected.ReadToEnd(), source.ReadToEnd());
        }
    }
}
