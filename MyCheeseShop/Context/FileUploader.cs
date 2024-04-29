using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace MyCheeseShop.Context
{
    public class FileUploader
    {
        private readonly IWebHostEnvironment _environment;
        private const long MAX_FILE_SIZE = 1024 * 1024 * 5; 
        private readonly string[] _allowedExtensions = [".jpg", ".jpeg", ".png", ".gif"];


        public FileUploader(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string?> UploadFileAsync(IBrowserFile file)
        {

            var imagesFolder = Path.Combine(_environment.WebRootPath, "img", "cheeses");
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);


            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.Name);
            var filePath = Path.Combine(imagesFolder, fileName);
            var fileExtension = Path.GetExtension(file.Name);


            if (file.Size > MAX_FILE_SIZE)
                return null;
            if (!_allowedExtensions.Contains(fileExtension))
                return null;

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream(MAX_FILE_SIZE).CopyToAsync(stream);
            }

            return fileName;
        }
    }
}