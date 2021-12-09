using DominicsPizza.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DominicsPizza.WebUI.Helpers
{
    public class FileHelper : IFileHelper
    {
        IWebHostEnvironment _environment;

        public FileHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void DeleteFile(string imageUrl)
        {
            throw new NotImplementedException();
        }

        public string UploadFile(IFormFile file)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "images");
            bool exists = Directory.Exists(uploads);

            if (!exists)
                Directory.CreateDirectory(uploads);

            var fileName = GenerateFileName(file.FileName);
            var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
            file.CopyToAsync(fileStream);

            return "/images/" + fileName;
        }

        private string GenerateFileName(string fileName)
        {
            string[] strName = fileName.Split('.');
            string strFileName = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[^1];
            return strFileName;
        }
    }
}
