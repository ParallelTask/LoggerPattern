using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.LoggerEvent
{
    public interface IAppLogger: ILogger
    {
        LogWriter Writer { get; }

        bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter, Object data);
    }
}
