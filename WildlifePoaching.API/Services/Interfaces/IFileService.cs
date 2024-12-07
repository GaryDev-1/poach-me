namespace WildlifePoaching.API.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string basePath, string fileName);
        Task DeleteFileAsync(string filePath);
        bool IsValidImage(IFormFile file);
    }
}
