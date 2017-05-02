using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalMVC2017.Utils
{
    public static class ProcessLogger
    {
        public static void Log(string message)
        {
            // write to console
            System.Diagnostics.Debug.WriteLine(message);

            // todo: implement Azure logging for Web Apps
            // Diagnostics Logging via Microsoft.Extensions.Logging.AzureAppServices
        }
    }
}
