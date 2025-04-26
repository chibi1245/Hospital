// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.




using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Hospital.Utilites
{
    public class ImageOperations
    {
        IWebHostEnvironment _env;

        public ImageOperations(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string ImageUpload(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string fileDirectory = Path.Combine(_env.WebRootPath, "images");
                fileName = Guid.NewGuid() + "-" + file.FileName;
                string filePath = Path.Combine(fileDirectory, fileName);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fs);
                }
            }
            return fileName;
        }
    }
}