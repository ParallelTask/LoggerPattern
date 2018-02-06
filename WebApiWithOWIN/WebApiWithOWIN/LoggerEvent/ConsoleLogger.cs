using Microsoft.Owin.Logging;
using NLog.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApiWithOWIN.Extensions;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.LoggerEvent
{
    public class ConsoleLogger : AppLogger
    {   
        public override LogWriter Writer => LogWriter.Console;

        public ConsoleLogger()
        {
            _logger = NLog.LogManager.GetLogger("console");
        }
    }
}