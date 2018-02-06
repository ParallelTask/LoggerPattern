using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiWithOWIN.LoggerService
{
    public interface ILoggerService
    {
        void WriteCritical(string message, LogWriter logWriter);

        void WriteCritical(string message, LogWriter logWriter, Object data);

        void WriteCritical(string message, Exception error, LogWriter logWriter);

        void WriteCritical(string message, Exception error, LogWriter logWriter, Object data);

        void WriteError(string message, LogWriter logWriter);

        void WriteError(string message, LogWriter logWriter, Object data);

        void WriteError(string message, Exception error, LogWriter logWriter);

        void WriteError(string message, Exception error, LogWriter logWriter, Object data);

        void WriteInformation(string message, LogWriter logWriter);

        void WriteInformation(string message, LogWriter logWriter, Object data);

        void WriteVerbose(string message, LogWriter logWriter);

        void WriteVerbose(string message, LogWriter logWriter, Object data);

        void WriteWarning(string message, LogWriter logWriter, params string[] args);

        void WriteWarning(string message, LogWriter logWriter, Object data, params string[] args);

        void WriteWarning(string message, Exception error, LogWriter logWriter);

        void WriteWarning(string message, Exception error, LogWriter logWriter, Object data);
    }
}
