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
    public class FileLogger: AppLogger
    {
        public override LogWriter Writer => LogWriter.File;

        public FileLogger()
        {
            _logger = new NLogFactory().Create("file");
        }
    }
}