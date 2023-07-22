using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetAppOOP
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CacheExpirationAttribute : Attribute
    {
        public int ExpirationTime { get; set; } // Cache expiration time in minutes
    }
}
