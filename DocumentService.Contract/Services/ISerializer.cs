using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentService.Contract.Services
{
    public interface ISerializer
    {
        string Serialize(IEnumerable<Uri> source);
    }
}
