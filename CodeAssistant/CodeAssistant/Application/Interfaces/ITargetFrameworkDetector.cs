namespace CodeAssistant.Application.Interfaces
{
    public interface ITargetFrameworkDetector
    {
        Task<bool> IsWindowsOnlyAsync(string solutionPath);
    }
}
