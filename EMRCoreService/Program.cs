using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
//using System.Web.Helpers;
using System.Xml;
using System.Xml.Serialization;

namespace EMRCoreService
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
