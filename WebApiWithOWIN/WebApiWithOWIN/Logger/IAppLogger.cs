using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.Logger
{
    public interface IAppLogger: ILogger
    {
        LogWriter Writer { get; }
    }
}
