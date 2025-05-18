namespace CodeAssistant.Infrastructure.Helpers
{
    public interface ISolutionFinder
    {
        public string? FindSolutionFile(string extractedPath);
    }
}
