using AnimalRescue.Services.FileUploadServices.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace AnimalRescue.Services.FileUploadServices
{
    public class FileUploadService : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> UploadFileAsync(IFormFile file, string repo, string name)
        {
            var repoPath = Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, repo));
            var filePath = Path.Combine(repoPath.ToString(), name + Path.GetExtension(file.FileName));


            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);


            return filePath;
        }
    }
}
