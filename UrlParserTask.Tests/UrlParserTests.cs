using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace UrlParserTask.Tests
{
    [TestFixture]
    public class UrlParserTests
    {
        [Test]
        public void UrlParser_WorksWithoutExceptions_Test()
        {
            new UrlParser().Run();
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
