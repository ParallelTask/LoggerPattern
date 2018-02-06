using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.LoggerAbstract
{
    public abstract class AppLogger : IAppLogger
    {
        protected ILogger _logger;

        public abstract LogWriter Writer { get; }

        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            _logger.WriteCore(eventType, eventId, state, exception, formatter);
            return true;
        }

    }
}