using CodeAssistant.Application.Interfaces;
using CodeAssistant.Infrastructure.Helpers;
using System.IO.Compression;

namespace CodeAssistant.Infrastructure.ApplicationServices
{
    public class ZipHandler : IZipHandler
    {
        private readonly IZipExtractor _zipExtractor;
        private readonly ISolutionFinder _solutionFinder;
        public ZipHandler(IZipExtractor zipExtractor, ISolutionFinder solutionFinder)
        {
            _zipExtractor = zipExtractor;
            _solutionFinder = solutionFinder;
        }

        public async Task<string> GetPathAsync(IFormFile zipFile)
        {
            var path = await _zipExtractor.SaveAndExtractAsync(zipFile);
            var solution = _solutionFinder.FindSolutionFile(path);
            return solution;
        }
    }
}
