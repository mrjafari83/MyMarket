using Microsoft.AspNetCore.Hosting;
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

        public void InformationLog(string message)
        {
            SaveLog("InformationLogs.txt" , message);
        }
        public void WarningLog(string message)
        {
            SaveLog("WarningLogs.txt", message);
        }
        public void ErrorLog(string message)
        {
            SaveLog("ErrorLogs.txt", message);
        }
        public void CriticalLog(string message)
        {
            SaveLog("CriticalLogs.txt", message);
        }

        private void SaveLog(string fileName , string message)
        {
            var address = _environment.WebRootPath + @"\Logs\" + fileName;

            if (File.Exists(address))
            {
                using (var writer = new StreamWriter(address , true))
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
