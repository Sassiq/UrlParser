using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace LoggerProviders
{
    public class CustomLogger : ILogger
    {
        private readonly ILogger _logger;

        public CustomLogger(ILoggerProvider loggerProvider)
        {
            this._logger = loggerProvider.CreateLogger("Log: ");
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this._logger.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return this._logger.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            this._logger.Log(logLevel, eventId, state, exception, formatter);
        }
    }
}
