using CodeAssistant.Application.Interfaces;
using CodeAssistant.Infrastructure.Helpers;
using System.IO.Compression;

namespace CodeAssistant.Infrastructure.ApplicationServices
{
    /// <summary>
    /// Extracts and saves .zip file to local directory
    /// using <see cref="IZipExtractor"/> and <see cref="ISolutionFinder"/> services.
    /// Runs asnychronously.
    /// </summary>
    public class ZipHandler : IZipHandler
    {
        /// <summary>
        /// Extracts and saves .zip file
        /// </summary>
        private readonly IZipExtractor _zipExtractor;
        /// <summary>
        /// Finds and return the path to .sln file
        /// </summary>
        private readonly ISolutionFinder _solutionFinder;
        /// <summary>
        /// Initializes an instance of the <see cref="ZipHandler"/> class
        /// </summary>
        /// <param name="zipExtractor">Used to extract and save .zip file to local directory.</param>
        /// <param name="solutionFinder">USed to find and return path to the .sln file.</param>
        public ZipHandler(IZipExtractor zipExtractor, ISolutionFinder solutionFinder)
        {
            _zipExtractor = zipExtractor;
            _solutionFinder = solutionFinder;
        }

        /// <summary>
        /// An asynchronous method used to extract and save .zip file locally
        /// and get the string wit path to the .sln file
        /// </summary>
        /// <param name="zipFile">The .zip file to be analyzed</param>
        /// <returns>Task with string containing path to the .sln file</returns>
        public async Task<string> GetPathAsync(IFormFile zipFile)
        {
            var path = await _zipExtractor.SaveAndExtractAsync(zipFile);
            var solution = _solutionFinder.FindSolutionFile(path);
            return solution;
        }
    }
}
