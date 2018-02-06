﻿using Microsoft.Owin.Logging;
using NLog.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.Logger
{
    public class ApiLogger : IAppLogger
    {
        private readonly ILogger _logger;

        public LogWriter Writer => LogWriter.API;
        
        public ApiLogger()
        {
            _logger = new NLogFactory().Create("api");
        }

        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            _logger.WriteCore(eventType, eventId, state, exception, formatter);
            return true;
        }
    }
}