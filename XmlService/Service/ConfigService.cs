//using Microsoft.Extensions.Configuration;
using System.Configuration;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
//using System.ServiceProcess;
//using System.Web.Helpers;
using System.Xml;
using System.Xml.Serialization;

namespace EMRService
{
    /// <summary>
    /// Read keys and values from  appsettings .json
    /// </summary>
    public static class ConfgService
    {
        public static IConfig config { get; set; }
        static ConfgService(){
            config = new Config();
        }

        public static string GetConfigValue(string Key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
        }
    }
    public class Config:IConfig
    {
        public string GetAppSettings(string Key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
        }
    }
    public interface IConfig
    {
        string GetAppSettings(string Key);
    }

}
