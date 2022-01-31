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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // managed objects
            }
            // unmanaged objects and resources
        }
    }
}
