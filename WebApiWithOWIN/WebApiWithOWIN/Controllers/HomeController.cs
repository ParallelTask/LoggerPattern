using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWithOWIN.Services;
using NLog.Owin.Logging;
using System.Diagnostics;
using WebApiWithOWIN.LoggerService;

namespace WebApiWithOWIN.Controllers
{
    public class HomeController : ApiController
    {
        private readonly ITest _test;

        public HomeController(ITest test, ILoggerService loggerService)
        {
            _test = test;

            var dictionary = new Dictionary<string, string>
            {
                { "UserId", "12345" }
            };

            loggerService.WriteInformation("Log this only to File", LogWriter.File);
            loggerService.WriteInformation("Log this to both File and Console", LogWriter.Console | LogWriter.File, dictionary);
            loggerService.WriteInformation("Log this to both File and Console", LogWriter.Console | LogWriter.File, new { User = "Bob", Age = 26 });
        }

        [HttpGet]
        public string Indexer()
        {
            return _test.Tester();
        }
    }
}
