using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace NurRealEstateWebApp.Service
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> UploadImages(Guid propertyId, IFormFile[] images)
        {
            var propertyDirectory = Path.Combine(webHostEnvironment.WebRootPath, "images", propertyId.ToString());
            Directory.CreateDirectory(propertyDirectory);

            for (int i = 0; i < images.Length; i++)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(images[i].FileName)}";
                var filePath = Path.Combine(propertyDirectory, fileName);

                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await images[i].CopyToAsync(stream);
                    }
                }
                catch (Exception)
                {
                    return false; // Return false to indicate failure
                }
            }

            return true; // Return true to indicate success
        }

    }
}