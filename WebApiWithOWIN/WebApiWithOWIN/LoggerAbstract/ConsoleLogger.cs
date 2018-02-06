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
    public class ConsoleLogger:  AppLogger
    {
        public override LogWriter Writer => LogWriter.Console;

        public ConsoleLogger()
        {
            _logger = new NLogFactory().Create("console");
        }
    }
}