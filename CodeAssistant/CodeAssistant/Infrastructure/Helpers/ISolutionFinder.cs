namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Used to find the .sln file in the directory.
    /// </summary>
    public interface ISolutionFinder
    {
        /// <summary>
        /// Finds the sln. file int given direectory.
        /// </summary>
        /// <param name="extractedPath">Path to the directory to be searched.</param>
        /// <returns>Path to the .sln file.</returns>
        public string? FindSolutionFile(string extractedPath);
    }
}
