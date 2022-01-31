using System;
using Microsoft.Extensions.Logging;
using NLog.Config;
using NLog.Extensions.Logging;

namespace LoggerProviders
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddNLog();
                });

            return loggerFactory.CreateLogger(categoryName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
