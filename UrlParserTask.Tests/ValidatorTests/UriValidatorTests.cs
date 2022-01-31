using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Validator.Implementations;

namespace UrlParserTask.Tests.ValidatorTests
{
    [TestFixture]
    public class UriValidatorTests
    {
        [TestCase("https://gitlab.com/Sassiq/url-parser", ExpectedResult = true)]
        [TestCase("https://habrahabr.ru/company/it-grad/blog/341486/", ExpectedResult = true)]
        [TestCase("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU", ExpectedResult = true)]
        [TestCase("https://github.com/AnzhelikaKravchuk?tab=repositories", ExpectedResult = true)]
        public bool UriValidator_Tests(string uri)
        {
            return new UriValidator().IsValid(new Uri(uri));
        }
    }
}
