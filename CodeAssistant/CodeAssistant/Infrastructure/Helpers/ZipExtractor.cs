using System.IO.Compression;

namespace CodeAssistant.Infrastructure.Helpers
{
    public class ZipExtractor : IZipExtractor
    {
        private readonly string _basePath;
        public ZipExtractor() 
        {
            _basePath = Path.Combine(Path.GetTempPath(), "SolutionUploads");
        }
        public async Task<string> SaveAndExtractAsync(IFormFile zipFile)
        {
            var id = Guid.NewGuid().ToString();
            var uploadPath = Path.Combine(_basePath, id);
            Directory.CreateDirectory(uploadPath);

            var zipPath = Path.Combine(uploadPath, "solution.zip");
            using (var stream = new FileStream(zipPath, FileMode.Create))
            {
                await zipFile.CopyToAsync(stream);
            }

            ZipFile.ExtractToDirectory(zipPath, uploadPath);

            File.Delete(zipPath); // clean up zip
            return uploadPath;
        }
    }
}
