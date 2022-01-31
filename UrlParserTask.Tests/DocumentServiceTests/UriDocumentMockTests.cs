using System;
using System.Collections.Generic;
using System.Text;
using DocumentService.Contract.Services;
using DocumentService.Implementations;
using Moq;
using NUnit.Framework;
using Storages.Contract.Storages;

namespace UrlParserTask.Tests.DocumentServiceTests
{
    [TestFixture]
    public class UriDocumentMockTests
    {
        [Test]
        public void UriDocumentCallsCheck()
        {
            var storage = new Mock<Storage>();
            var serializer = new Mock<ISerializer>();
            var deserializer = new Mock<IDeserializer>();
            
            UriDocumentService service = new UriDocumentService(storage.Object, serializer.Object, deserializer.Object);

            service.Run();

            storage.Verify(s => s.GetData(), Times.Once);
            serializer.Verify(s => s.Serialize(It.IsAny<IEnumerable<Uri>>()), Times.Once);
            deserializer.Verify(d => d.Deserialize(It.IsAny<string>()), Times.Once);
        }
    }
}
