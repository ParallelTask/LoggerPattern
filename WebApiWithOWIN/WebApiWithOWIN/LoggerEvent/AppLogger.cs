using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApiWithOWIN.Extensions;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.LoggerEvent
{
    public abstract class AppLogger : IAppLogger
    {
        private readonly Func<TraceEventType, NLog.LogLevel> getLogLevel = DefaultGetLogLevel;

        private static NLog.LogLevel DefaultGetLogLevel(TraceEventType traceEventType)
        {
            switch (traceEventType)
            {
                case TraceEventType.Resume:
                    return NLog.LogLevel.Debug;
                case TraceEventType.Transfer:
                    return NLog.LogLevel.Debug;
                case TraceEventType.Stop:
                    return NLog.LogLevel.Debug;
                case TraceEventType.Suspend:
                    return NLog.LogLevel.Debug;
                case TraceEventType.Verbose:
                    return NLog.LogLevel.Trace;
                case TraceEventType.Start:
                    return NLog.LogLevel.Debug;
                case TraceEventType.Critical:
                    return NLog.LogLevel.Fatal;
                case TraceEventType.Error:
                    return NLog.LogLevel.Error;
                case TraceEventType.Warning:
                    return NLog.LogLevel.Warn;
                case TraceEventType.Information:
                    return NLog.LogLevel.Info;
                default:
                    throw new ArgumentOutOfRangeException(nameof(traceEventType));
            }
        }

        protected NLog.ILogger _logger;

        public abstract LogWriter Writer { get; }

        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            return this.WriteCore(eventType, eventId, state, exception, formatter, new Dictionary<string, string>());
        }

        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter, object data)
        {
            // NLOG logger
            var level = this.getLogLevel(eventType);
            var logEvent = NLog.LogEventInfo.Create(level, _logger.Name, exception, _logger.Factory.DefaultCultureInfo, formatter(state, exception));

            var dictionary = data.ToDictionary<string>();

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                logEvent.Properties.Add(item.Key, item.Value);
            }

            _logger.Log(logEvent);

            return true;
        }
    }
}