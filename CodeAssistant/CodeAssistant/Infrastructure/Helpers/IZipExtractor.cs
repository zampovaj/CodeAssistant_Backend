namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Used to extract and save locally a .zip file.
    /// </summary>
    public interface IZipExtractor
    {
        /// <summary>
        /// Takes a .zip file, extracts it, and saves it to local directory.
        /// Runs asynchronously.
        /// </summary>
        /// <param name="zipFile">The .zip file to be saved. Comes from API request.</param>
        /// <returns><see cref="Task"/> containing string with path to the extracted file.</returns>
        Task<string> SaveAndExtractAsync(IFormFile zipFile);
    }
}
