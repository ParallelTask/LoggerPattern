using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithOWIN.LoggerService
{
    [Flags]
    public enum LogWriter : byte
    {
        Console = 0,
        API = 1,
        File = 2,
        IncludeAll = Console | File | API
    }
}