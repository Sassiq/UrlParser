using System;
using System.Collections.Generic;
using System.Text;

namespace Storages.Contract.Storages
{
    public interface IDataPersister
    {
        void SaveData(string data);
    }
}
