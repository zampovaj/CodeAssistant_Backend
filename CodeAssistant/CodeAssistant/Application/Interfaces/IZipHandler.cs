namespace CodeAssistant.Application.Interfaces
{
    /// <summary>
    /// Gets .zip file, saves it locally and returns the path
    /// </summary>
    public interface IZipHandler
    {
        /// <summary>
        /// Asnychronous method used to extract ans save to local directory .zip file
        /// </summary>
        /// <param name="zipFile">.zip file of the Solution to be analyzed</param>
        /// <returns>PAtht to the local directory with extracted solution</returns>
        Task<string> GetPathAsync(IFormFile zipFile);
    }
}
