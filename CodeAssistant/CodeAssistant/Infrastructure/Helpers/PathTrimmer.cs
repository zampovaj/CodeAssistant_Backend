namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Trims the static path to file and makes it dynamic.
    /// </summary>
    public class PathTrimmer : IPathTrimmer
    {
        /// <summary>
        /// Represents the base path = the part of fullPath to be removed.
        /// </summary>
        string _basePath = Path.Combine(Path.GetTempPath(), "SolutionUploads");
        /// <summary>
        /// Trims the static part of the path.
        /// Removes redundant slashes.
        /// </summary>
        /// <param name="fullPath">Path o be trimmed.</param>
        /// <returns>Trimmed path ready to be passed to the user.</returns>
        public string TrimPath(string fullPath)
        {
            string remainingPath = fullPath.Substring(_basePath.Length);
            remainingPath = remainingPath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            // remove redundant slash
            int slashIndex = remainingPath.IndexOf(Path.DirectorySeparatorChar);
            if (slashIndex < 0)
                return remainingPath;

            return remainingPath.Substring(slashIndex + 1);
        }
    }
}
