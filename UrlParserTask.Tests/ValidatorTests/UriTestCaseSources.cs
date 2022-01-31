using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace UrlParserTask.Tests.ValidatorTests
{
    public static class UriTestCaseSources
    {
        public static IEnumerable<TestCaseData> ValidUries
        {
            get
            {
                yield return new TestCaseData(new Uri("https://gitlab.com/Sassiq/url-parser"));
                yield return new TestCaseData(new Uri("https://habrahabr.ru/company/it-grad/blog/341486/"));
                yield return new TestCaseData(new Uri("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU"));
                yield return new TestCaseData(new Uri("https://github.com/AnzhelikaKravchuk?tab=repositories"));
            }
        }
    }
}
