using AnimalRescue.Models;
using AnimalRescue.Services.FileServices.Interfaces;

namespace AnimalRescue.Services.FileServices
{
    public class FileDeleteService : IFileDelete
    {
        private readonly IWebHostEnvironment _environment;

        public FileDeleteService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void RemoveDirectoryWithFile(string directoryPath)
        {
            var repo = $"wwwroot\\Repo\\{directoryPath}";
            var repoPath = Path.Combine(_environment.ContentRootPath, repo);

            Directory.Delete(repoPath, true);
        }

        public void RemoveFile(AnimalModel animal)
        {
            var repo = $"wwwroot\\Repo\\Animals\\{animal.ShelterId}\\{animal.PhotoFileName}";
            var repoPath = Path.Combine(_environment.ContentRootPath, repo);

            File.Delete(repoPath);
        }
    }
}
