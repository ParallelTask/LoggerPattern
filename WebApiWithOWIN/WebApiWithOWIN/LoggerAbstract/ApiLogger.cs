using Microsoft.Owin.Logging;
using NLog.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.LoggerAbstract
{
    public class ApiLogger : AppLogger
    {
        public override LogWriter Writer => LogWriter.API;

        public ApiLogger()
        {
            _logger = new NLogFactory().Create("api");
        }
    }
}