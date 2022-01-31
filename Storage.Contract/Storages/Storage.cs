using System;
using System.Collections.Generic;
using System.Text;

namespace Storages.Contract.Storages
{
    public abstract class Storage : IDataPersister, IDataReceiver
    {
        public abstract string GetData();

        public abstract void SaveData(string data);
    }
}
