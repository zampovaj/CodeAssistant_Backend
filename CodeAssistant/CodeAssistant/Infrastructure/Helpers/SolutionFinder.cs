namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Searches for and returns .sln file given directory.
    /// </summary>
    public class SolutionFinder : ISolutionFinder
    {
        /// <summary>
        /// Finds the sln. file int given direectory.
        /// </summary>
        /// <param name="extractedPath">Path to the directory to be searched.</param>
        /// <returns>Path to the .sln file.</returns>
        public string? FindSolutionFile(string extractedPath)
        {
            return Directory.GetFiles(extractedPath, "*.sln", SearchOption.AllDirectories).FirstOrDefault();
        }
    }
}
