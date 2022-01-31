using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentService.Contract.Services
{
    public interface IDeserializer
    {
        IEnumerable<Uri> Deserialize(string source);
    }
}
