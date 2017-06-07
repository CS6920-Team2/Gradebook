using DbUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbUpRunner
{
    class Program
    {
        private static readonly string DEFAULT_CONNECTION_STRING = "Server=(local)\\MSSQLSERVER; Database=Gradebook; Trusted_connection=true";
        private static readonly int SUCCESS = 0;
        private static readonly int ERROR = -1;
        static int Main(string[] args)
        {
            String connectionString;
            if(args.Length > 0)
            {
                connectionString = String.Join(String.Empty, args).Replace("UserId", "User Id").Replace("\\\\", "\\");
            }
            else
            {
                connectionString = DEFAULT_CONNECTION_STRING;
            }

            Console.WriteLine(connectionString);
            //This will create the database specified in the connection string if it does not exist
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return ERROR;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");
            Console.ResetColor();
            return SUCCESS;
        }
    }
}
