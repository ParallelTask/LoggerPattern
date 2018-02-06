using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithOWIN.Services
{
    public class Test : ITest
    {
        public string Tester()
        {
            return "hello Tester";
        }
    }
}