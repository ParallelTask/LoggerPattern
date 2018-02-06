using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Logging;
using WebApiWithOWIN.LoggerService;
using WebApiWithOWIN.Extensions;
using WebApiWithOWIN.Extensions.MDLC;

namespace WebApiWithOWIN.LoggerAbstract
{
    public class LoggerService : ILoggerService
    {
        private List<IAppLogger> _loggers = new List<IAppLogger>();

        public LoggerService(IEnumerable<IAppLogger> loggers)
        {
            _loggers.AddRange(loggers);
        }

        public void WriteCritical(string message, LogWriter logWriter)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteCritical(message));
        }

        public void WriteCritical(string message, LogWriter logWriter, Object data)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteCritical(message, data));
        }

        public void WriteCritical(string message, Exception error, LogWriter logWriter)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteCritical(message, error));
        }

        public void WriteCritical(string message, Exception error, LogWriter logWriter, Object data)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteCritical(message, error, data));
        }

        public void WriteError(string message, LogWriter logWriter)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteError(message));
        }

        public void WriteError(string message, LogWriter logWriter, Object data)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteError(message, data));
        }

        public void WriteError(string message, Exception error, LogWriter logWriter)
        {
            _loggers
                .Where(x => logWriter == x.Writer)
                .ToList()
                .ForEach(x => x.WriteError(message, error));
        }

        public void WriteError(string message, Exception error, LogWriter logWriter, Object data)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteError(message, error, data));
        }

        public void WriteInformation(string message, LogWriter logWriter)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteInformation(message));
        }

        public void WriteInformation(string message, LogWriter logWriter, Object data)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteInformation(message, data));
        }

        public void WriteVerbose(string message, LogWriter logWriter)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteVerbose(message));
        }

        public void WriteVerbose(string message, LogWriter logWriter, Object data)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteVerbose(message, data));
        }

        public void WriteWarning(string message, LogWriter logWriter, params string[] args)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteWarning(message, args));
        }

        public void WriteWarning(string message, LogWriter logWriter, Object data, params string[] args)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteWarning(message, data, args));
        }

        public void WriteWarning(string message, Exception error, LogWriter logWriter)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteWarning(message, error));
        }

        public void WriteWarning(string message, Exception error, LogWriter logWriter, Object data)
        {
            _loggers
                .Where(x => logWriter.HasFlag(x.Writer))
                .ToList()
                .ForEach(x => x.WriteWarning(message, error, data));
        }
    }
}