using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Services
{
    public class PhotoService
    {
        private readonly IWebHostEnvironment _env;

        public PhotoService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string SavePhoto(IFormFile file)
        {
            if (file == null) return null;
            var pictureUri = file.FileName;
            var path = Path.Combine(_env.WebRootPath, "uploads", "products", pictureUri);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return pictureUri;
        }

        public void DeletePhoto(string pictureUri)
        {
            if (string.IsNullOrEmpty(pictureUri)) return;
            try
            {
                var deletePath = Path.Combine(_env.WebRootPath, "uploads", "products", pictureUri);
                System.IO.File.Delete(deletePath);
            }
            catch (Exception) { }
        }
    }
}
