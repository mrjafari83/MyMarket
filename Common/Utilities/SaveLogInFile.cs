using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public class SaveLogInFile
    {
        private readonly IHostingEnvironment _environment;
        public SaveLogInFile(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void Log(LogLevel logLevel, string message, HttpContext context)
        {
            var address = _environment.WebRootPath + @"\Logs\Log_" + DateTime.Now.ToString("yyyy_M_d") + ".txt";
            message = $"[{logLevel}] _ " + DateTime.Now.ToString("G") + " _ " + context.Request.Path + context.Request.QueryString + " _ Message is : " + message;

            if (File.Exists(address))
            {
                using (var writer = new StreamWriter(address, true))
                    writer.WriteLine(message);
            }
            else
            {
                using (var writer = File.CreateText(address))
                    writer.WriteLine(message);

            }
        }
    }
}
