using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentService.Contract.Services;
using Microsoft.Extensions.Logging;
using Validator.Contract;

namespace DocumentService.Implementations
{
    public class UriDocumentDeserializer : IDeserializer
    {
        private readonly ILogger _logger;
        private readonly IValidator _validator;

        public UriDocumentDeserializer(ILogger logger, IValidator validator)
        {
            this._logger = logger;
            this._validator = validator;
        }

        public IEnumerable<Uri> Deserialize(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                this._logger.Log(LogLevel.Critical, "Deserializable source was null or empty.");
                throw new ArgumentNullException(nameof(source));
            }

            return DeserializeIterator(source);

            IEnumerable<Uri> DeserializeIterator(string sourceString)
            {
                using StringReader stringReader = new StringReader(sourceString);
                while (stringReader.Peek() != -1)
                {
                    string currentString = stringReader.ReadLine();
                    this._logger.Log(LogLevel.Information, $"Deserializing: {currentString}");
                    Uri uri;

                    try
                    {
                        uri = new Uri(currentString);
                    }
                    catch (Exception ex)
                    {
                        this._logger.Log(LogLevel.Critical, $"{ex.Message}");
                        throw;
                    }

                    if (!this._validator.IsValid(uri))
                    {
                        string exceptionMessage = "Uri is incorrect";
                        this._logger.Log(LogLevel.Critical, exceptionMessage);
                        throw new ArgumentException(exceptionMessage);
                    }

                    yield return uri;
                }
            }
        }
    }
}
