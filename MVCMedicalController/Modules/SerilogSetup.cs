using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Serilog;
using ILogger = Serilog.ILogger;

namespace MVCMedicalController.Modules
{
    public class SerilogSetup : IDisposable
    {
        public static ILogger CreateSerilogLogger()
        {
            var dir = Path.GetDirectoryName(typeof(SerilogSetup).Assembly.Location);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithProperty("ApplicationContext", "MVCMedicalController")
                .CreateLogger();
            Log.Information("Created");
            return Log.Logger;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
