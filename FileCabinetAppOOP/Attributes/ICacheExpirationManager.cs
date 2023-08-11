using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetAppOOP.Attributes
{
    public interface ICacheExpirationManager
    {
        static abstract int GetCacheExpirationTime(Type documentType);
    }
}
