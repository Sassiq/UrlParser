using System;
using System.Collections.Generic;
using System.Text;
using DocumentService.Contract.Services;
using Storages.Contract.Storages;

namespace DocumentService.Implementations
{
    public class UriDocumentService : IDocumentService
    {
        private readonly Storage _storage;
        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        public UriDocumentService(Storage storage, ISerializer serializer, IDeserializer deserializer)
        {
            this._storage = storage;
            this._deserializer = deserializer;
            this._serializer = serializer;
        }

        public void Run()
        {
            string documentAsString = _storage.GetData();
            var uris = _deserializer.Deserialize(documentAsString);
            var xmlDoc = _serializer.Serialize(uris);
            _storage.SaveData(xmlDoc);
        }
    }
}
