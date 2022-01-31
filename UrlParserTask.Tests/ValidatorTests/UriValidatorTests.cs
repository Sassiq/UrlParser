using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Validator.Implementations;

#pragma warning disable CA1707 //Underscores in method names

namespace UrlParserTask.Tests.ValidatorTests
{
    [TestFixture]
    public class UriValidatorTests
    {
        [TestCaseSource(typeof(UriTestCaseSources), nameof(UriTestCaseSources.ValidUries))]
        public void UriValidator_Tests(Uri uri)
        {
            Assert.AreEqual(true, new UriValidator().IsValid(uri));
        }
    }
}
