using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Helpers
{
    public static class Help
    {
        public static async Task<string> SaveFileAsync(IFormFile file, string path)
        {
            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + path /*FolderPath*/;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);

            // Merge The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);


            // Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create)) // save like 0 1 
            {
                await file.CopyToAsync(Stream);
            }
            return FileName;
        }

    }
}
