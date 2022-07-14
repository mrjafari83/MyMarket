using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utilities
{
    public class SaveLogInFile
    {
        private readonly string RootPath;
        public SaveLogInFile()
        {
            this.RootPath = Environment.CurrentDirectory;
        }

        public void Log(LogLevel logLevel, string message, HttpContext context)
        {
            var folder = RootPath + @"\Logs";
            var file = "Log_" + DateTime.Now.ToString("yyyy_M_d") + ".txt";
            var address = Path.Combine(folder, file);
            message = $"[{logLevel}] _ " + DateTime.Now.ToString("G") + " _ " + context.Request.Path + context.Request.QueryString + " _ Message is : " + message;

            if (File.Exists(address))
            {
                using (var writer = new StreamWriter(address, true))
                    writer.WriteLine(message);
            }
            else
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                using (var writer = File.CreateText(address))
                    writer.WriteLine(message);

            }
        }

        public void Log(LogLevel logLevel, string message, string errorPath)
        {
            var folder = RootPath + @"\Logs";
            var file = "Log_" + DateTime.Now.ToString("yyyy_M_d") + ".txt";
            var address = Path.Combine(folder, file);
            message = $"[{logLevel}] _ " + DateTime.Now.ToString("G") + " _ " + errorPath + " _ Message is : " + message;

            if (File.Exists(address))
            {
                using (var writer = new StreamWriter(address, true))
                    writer.WriteLine(message);
            }
            else
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                using (var writer = File.CreateText(address))
                    writer.WriteLine(message);

            }
        }
    }
}
