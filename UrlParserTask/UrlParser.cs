using System;
using DependencyResolver;
using DocumentService.Contract.Services;
using Microsoft.Extensions.DependencyInjection;

#pragma  warning  disable CA1822

namespace UrlParserTask
{
    public class UrlParser
    {
        public void Run()
        {
            new ResolverConfig().CreateServiceProvider().GetService<IDocumentService>().Run();
        }
    }
}
