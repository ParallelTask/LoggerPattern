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
    public class ApiLogger : AppLogger
    {   
        public override LogWriter Writer => LogWriter.Console;

        public ApiLogger()
        {
            _logger = NLog.LogManager.GetLogger("api");
        }
    }
}