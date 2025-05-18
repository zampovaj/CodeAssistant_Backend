namespace CodeAssistant.Infrastructure.Helpers
{
    public class SolutionFinder : ISolutionFinder
    {
        public string? FindSolutionFile(string extractedPath)
        {
            return Directory.GetFiles(extractedPath, "*.sln", SearchOption.AllDirectories).FirstOrDefault();
        }
    }
}
