using Microsoft.Extensions.Configuration;
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
    /// <summary>
    /// Read keys and values from  appsettings .json
    /// </summary>
    public static class ConfgService
    {
        public static IConfiguration config { get; set; }
        static ConfgService()
        {
            config = LoadConfig();
        }
        private static IConfigurationRoot LoadConfig()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            return configuration;
        }
    }
}
