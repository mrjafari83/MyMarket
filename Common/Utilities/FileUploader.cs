using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class FileUploader
    {
        public static async Task<string> Upload(IFormFile file , IHostingEnvironment environment, string path)
        {
            if(file != null)
            {
                string folderAddress = $@"/Images/" + path + "/";
                string rootFolder = environment.WebRootPath + folderAddress;

                if (!Directory.Exists(rootFolder))
                {
                    Directory.CreateDirectory(rootFolder);
                }

                string fileName = Guid.NewGuid().ToString() + file.FileName;
                var fileAddress = Path.Combine(rootFolder, fileName);

                using(var fileStream = new FileStream(fileAddress , FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return folderAddress + fileName;
            }

            return null;
        }

        public static bool Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }
    }
}
