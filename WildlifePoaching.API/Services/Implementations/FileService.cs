using FluentValidation;
using WildlifePoaching.API.Services.Interfaces;

namespace WildlifePoaching.API.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png" };
        private const long MaxFileSize = 5 * 1024 * 1024; // 5MB

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string basePath, string fileName)
        {
            if (!IsValidImage(file))
                throw new ValidationException("Invalid file type or size");

            var filePath = Path.Combine(basePath, fileName);
            var directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        public async Task DeleteFileAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public bool IsValidImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            if (file.Length > MaxFileSize)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return _allowedExtensions.Contains(extension);
        }
    }
}
