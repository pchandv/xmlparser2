using System;
using System.IO;
using System.ServiceProcess;

namespace EMRCoreService
{
    //To run this console as service , we have to register our service from Service base class
    class RegisterParseService : ServiceBase
    {
        private string _logFileLocation = ConfgService.config.GetSection(AppConstants.Appsettings)[AppConstants.LogsPath];

        private void SetupAndRun(string logMessage)
        {
           Directory.CreateDirectory(Path.GetDirectoryName(_logFileLocation));
           File.AppendAllText(_logFileLocation, DateTime.UtcNow.ToString() + " : " + logMessage + Environment.NewLine);
           Watcher.Run();
        }

        protected override void OnStart(string[] args)
        {
            SetupAndRun("Starting");
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            SetupAndRun("Stopping");
            base.OnStop();
        }

        protected override void OnPause()
        {
            SetupAndRun("Pausing");
            base.OnPause();
        }
    }
}