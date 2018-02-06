using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using NLog.StructuredLogging.Json;
using Newtonsoft.Json;

namespace WebApiWithOWIN.Extensions.MDLC
{
    
    public static class OWINLoggerExtensionsMdlc
    {
        private static void SetMDLC(Object data)
        {
            var dictionary = data.ToDictionary<string>();

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                NLog.MappedDiagnosticsLogicalContext.Set(item.Key, item.Value);
            }
        }

        private static void UnsetMDLC(Object data)
        {
            var dictionary = data.ToDictionary<string>();

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                NLog.MappedDiagnosticsLogicalContext.Remove(item.Key);
            }
        }

        public static void WriteCritical(this ILogger logger, string message, Object data)
        { 
            SetMDLC(data);
            logger.WriteCritical(message);
            UnsetMDLC(data);
        }

        public static void WriteCritical(this ILogger logger, string message, Exception error, Object data)
        {
            SetMDLC(data);
            logger.WriteCritical(message, error);
            UnsetMDLC(data);
        }

        public static void WriteError(this ILogger logger, string message, Object data)
        {
            SetMDLC(data);
            logger.WriteError(message);
            UnsetMDLC(data);
        }

        public static void WriteError(this ILogger logger, string message, Exception error, Object data)
        {
            SetMDLC(data);
            logger.WriteError(message, error);
            UnsetMDLC(data);
        }

        public static void WriteInformation(this ILogger logger, string message, Object data)
        {
            SetMDLC(data);
            logger.WriteInformation(message);
            UnsetMDLC(data);
        }

        public static void WriteVerbose(this ILogger logger, string message, Object data)
        {
            
            SetMDLC(data);
            logger.WriteVerbose(message);
            UnsetMDLC(data);
        }

        public static void WriteWarning(this ILogger logger, string message, Object data, params string[] args)
        {
            SetMDLC(data);
            logger.WriteWarning(message, args);
            UnsetMDLC(data);
        }

        public static void WriteWarning(this ILogger logger, string message, Exception error, Object data)
        {
            SetMDLC(data);
            logger.WriteWarning(message, error);
            UnsetMDLC(data);
        }
    }
}