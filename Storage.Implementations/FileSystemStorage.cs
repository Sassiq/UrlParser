using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Storages.Contract.Storages;

namespace Storages.Implementations
{
    public class FileSystemStorage : Storage
    {
        private readonly string _sourceFilPath;
        private readonly string _destinationFilPath;

        public FileSystemStorage(string sourceFilePath, string destinationFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath))
            {
                throw new ArgumentException(nameof(sourceFilePath));
            }

            if (string.IsNullOrWhiteSpace(destinationFilePath))
            {
                throw new ArgumentException(nameof(destinationFilePath));
            }

            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException(nameof(sourceFilePath));
            }

            this._sourceFilPath = sourceFilePath;
            this._destinationFilPath = destinationFilePath;
        }

        public override string GetData()
        {
            using var sourceStreamReader = new StreamReader(File.OpenRead(_sourceFilPath));
            return sourceStreamReader.ReadToEnd();
        }

        public override void SaveData(string data)
        {
            using var outputStreamWriter = new StreamWriter(File.Open(_destinationFilPath, FileMode.Create, FileAccess.Write));
            outputStreamWriter.Write(data);
        }
    }
}
