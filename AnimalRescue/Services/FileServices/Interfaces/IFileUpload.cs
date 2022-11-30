using Microsoft.AspNetCore.WebUtilities;

namespace AnimalRescue.Services.FileUploadServices.Interfaces
{
    public interface IFileUpload
    {
        public Task<string> UploadFileAsync(IFormFile file, string repo, string id);
    }
}
