using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gradebook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly String SUCCESS = "Success";
        private readonly String DATABASE_CONNECTION_KEY = "database_connection";
        private readonly String DB_UP_RUNNER_EXE = "DbUpRunner.exe";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            RunPendingDbScripts();
        }

        /// <summary>
        /// Executes the DbUpRunner application which will check to see if there 
        /// are any scripts to run against the local db
        /// </summary>
        private void RunPendingDbScripts()
        {
            if (File.Exists(DB_UP_RUNNER_EXE))
            {
                Process dbUp;
                Object connectionString = this.TryFindResource(DATABASE_CONNECTION_KEY);
                if (connectionString == null)
                {
                    dbUp = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = DB_UP_RUNNER_EXE,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                }
                else
                {
                    dbUp = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = DB_UP_RUNNER_EXE,
                            Arguments = connectionString.ToString(),
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                }

                try
                {
                    dbUp.Start();
                    String status = String.Empty;
                    while (!dbUp.StandardOutput.EndOfStream)
                    {
                        status = dbUp.StandardOutput.ReadLine().ToString();
                    }

                    if (status != SUCCESS)
                    {
                        throw new Exception("DbUp failed to execute, stopping the application");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Application.Current.Shutdown();
                }
            }
        }
    }
}
