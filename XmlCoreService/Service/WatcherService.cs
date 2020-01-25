using System;
using System.IO;
using System.ServiceProcess;

namespace EMRCoreService
{
    using System;
    using System.IO;
    using System.Security.Permissions;

    public class Watcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
          
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = ConfgService.config.GetSection(AppConstants.Appsettings)[AppConstants.UploadPath]; //args[1];

              
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

             
                watcher.Filter = "*.xml";

                // Add event handlers.
               // watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
              //  watcher.Deleted += OnChanged;
               // watcher.Renamed += OnChanged;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

      
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
           
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            ParseXMLService.ReadAll();

        }
    }
}