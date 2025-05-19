namespace CodeAssistant.Infrastructure.Helpers
{
    public class PathTrimmer : IPathTrimmer
    {
        string _basePath = Path.Combine(Path.GetTempPath(), "SolutionUploads");
        public string TrimPath(string fullPath)
        {
            string remainingPath = fullPath.Substring(_basePath.Length);
            remainingPath = remainingPath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            int slashIndex = remainingPath.IndexOf(Path.DirectorySeparatorChar);
            if (slashIndex < 0)
                return remainingPath;

            return remainingPath.Substring(slashIndex + 1);
        }
    }
}
