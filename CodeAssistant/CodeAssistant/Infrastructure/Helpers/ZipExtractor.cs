using System.IO.Compression;

namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Extracts and saves .zip file to local directory.
    /// </summary>
    public class ZipExtractor : IZipExtractor
    {
        /// <summary>
        /// Represents the path in which we save the extrcated file.
        /// </summary>
        private readonly string _basePath;
        /// <summary>
        /// Initializes new <see cref="ZipExtractor"/> instance.
        /// Assigns value to <see cref="_basePath"/>.
        /// </summary>
        public ZipExtractor() 
        {
            _basePath = Path.Combine(Path.GetTempPath(), "SolutionUploads");
        }

        /// <summary>
        /// Takes a .zip file, extracts it, and saves it to local directory.
        /// Runs asynchronously.
        /// </summary>
        /// <param name="zipFile">The .zip file to be saved. Comes from API request.</param>
        /// <returns><see cref="Task"/> containing string with path to the extracted file.</returns>
        public async Task<string> SaveAndExtractAsync(IFormFile zipFile)
        {
            // creates unique folder for teh newly extracted solution
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
