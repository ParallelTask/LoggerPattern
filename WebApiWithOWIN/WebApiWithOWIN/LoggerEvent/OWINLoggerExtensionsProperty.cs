using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using NLog.StructuredLogging.Json;
using Newtonsoft.Json;
using WebApiWithOWIN.Extensions;

namespace WebApiWithOWIN.LoggerEvent.Extensions
{
    public static class OWINLoggerExtensionsProperty
    {
        private static readonly Func<object, Exception, string> TheMessage = (message, error) => (string)message;
        private static readonly Func<object, Exception, string> TheMessageAndError = (message, error) => string.Format(CultureInfo.CurrentCulture, "{0}\r\n{1}", message, error);

        public static void ExtendWriteCritical(this IAppLogger logger, string message, Object data)
        {
            logger.WriteCore(TraceEventType.Critical, 0, message, null, TheMessage, data);
        }

        public static void ExtendWriteCritical(this IAppLogger logger, string message, Exception error, Object data)
        {
            logger.WriteCore(TraceEventType.Critical, 0, message, error, TheMessageAndError, data);
        }

        public static void ExtendWriteError(this IAppLogger logger, string message, Object data)
        {
            logger.WriteCore(TraceEventType.Error, 0, message, null, TheMessage, data);
        }

        public static void ExtendWriteError(this IAppLogger logger, string message, Exception error, Object data)
        {
            logger.WriteCore(TraceEventType.Error, 0, message, error, TheMessageAndError, data);
        }

        public static void ExtendWriteInformation(this IAppLogger logger, string message, Object data)
        {
            logger.WriteCore(TraceEventType.Information, 0, message, null, TheMessage, data);
        }

        public static void ExtendWriteVerbose(this IAppLogger logger, string message, Object data)
        {
            logger.WriteCore(TraceEventType.Verbose, 0, message, null, TheMessage, data);
        }

        public static void ExtendWriteWarning(this IAppLogger logger, string message, Object data, params string[] args)
        {
            logger.WriteCore(
                TraceEventType.Warning, 0, string.Format(CultureInfo.InvariantCulture, message, args), null, TheMessage, data); ;
        }

        public static void ExtendWriteWarning(this ILogger logger, string message, Exception error, Object data)
        {
            logger.WriteCore(TraceEventType.Warning, 0, message, error, TheMessageAndError);
        }
    }
}