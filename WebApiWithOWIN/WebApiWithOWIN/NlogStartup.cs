using System;
using System.Diagnostics;
using Autofac;
using NLog;

namespace WebApiWithOWIN
{
    public class WebApiWithOWIN : IStartable
    {
        public void Start()
        {
            EnabledLevelForAllRules(TraceEventType.Information);
        }

        private static LogLevel DefaultGetLogLevel(TraceEventType traceEventType)
        {
            switch (traceEventType)
            {
                case TraceEventType.Resume:
                    return LogLevel.Debug;
                case TraceEventType.Transfer:
                    return LogLevel.Debug;
                case TraceEventType.Stop:
                    return LogLevel.Debug;
                case TraceEventType.Suspend:
                    return LogLevel.Debug;
                case TraceEventType.Verbose:
                    return LogLevel.Trace;
                case TraceEventType.Start:
                    return LogLevel.Debug;
                case TraceEventType.Critical:
                    return LogLevel.Fatal;
                case TraceEventType.Error:
                    return LogLevel.Error;
                case TraceEventType.Warning:
                    return LogLevel.Warn;
                case TraceEventType.Information:
                    return LogLevel.Info;
                default:
                    throw new ArgumentOutOfRangeException(nameof(traceEventType));
            }
        }

        public static void EnabledLevelForAllRules(TraceEventType traceEventType)
        {
            var logLevel = DefaultGetLogLevel(traceEventType);
            foreach (var rule in LogManager.Configuration.LoggingRules)
            {
                foreach (var level in LogLevel.AllLevels)
                {
                    rule.DisableLoggingForLevel(level);
                }

                rule.EnableLoggingForLevels(logLevel, LogLevel.Fatal);
            }
            //Call to update existing Loggers created with GetLogger() or 
            //GetCurrentClassLogger()
            LogManager.ReconfigExistingLoggers();
        }

    }
}