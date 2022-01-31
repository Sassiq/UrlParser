using System;
using System.IO;
using DocumentService.Contract.Services;
using DocumentService.Implementations;
using LoggerProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Storages.Contract.Storages;
using Storages.Implementations;
using Validator.Contract;
using Validator.Implementations;

#pragma warning disable SA3928 // The parameter name should be declared in the argument list.

namespace DependencyResolver
{
    public class ResolverConfig
    {
        public IConfiguration ConfigurationRoot { get; } =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public IServiceProvider CreateServiceProvider()
        {
            string sourceFilePath = this.CreatePath("sourceFilePath") ?? throw new ArgumentNullException("CreatePath(\"sourceFilePath\")");
            string targetFilePath = this.CreatePath("targetFilePath") ?? throw new ArgumentNullException("CreatePath(\"targetFilePath\")");

            return new ServiceCollection()
                .AddTransient<ILoggerProvider, CustomLoggerProvider>()
                .AddTransient<ILogger, CustomLogger>()
                .AddTransient<IValidator, UriValidator>()
                .AddTransient<IDeserializer, UriDocumentDeserializer>()
                .AddTransient<ISerializer, XmlDocumentSerializer>()
                .AddTransient<Storage>(s => new FileSystemStorage(sourceFilePath, targetFilePath))
                .AddTransient<IDocumentService, UriDocumentService>()
                .BuildServiceProvider();
        }

        private string CreatePath(string path) => Path.Combine(Directory.GetCurrentDirectory(), this.ConfigurationRoot[path]);
    }
}
