
using EMRCoreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EMRService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Comment below when doing testing locally
            //ServiceBase.Run(new RegisterParseService());

            //Uncomment below for testing locally
            Watcher.Run();
        }
    }
}
