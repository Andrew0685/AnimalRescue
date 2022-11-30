using AnimalRescue.Models;

namespace AnimalRescue.Services.FileServices.Interfaces
{
    public interface IFileDelete
    {
        public void RemoveDirectoryWithFile(string directoryPath);
        public void RemoveFile(AnimalModel animal);
    }
}
