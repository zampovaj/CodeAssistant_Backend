using CodeAssistant.Domain.Models;

namespace CodeAssistant.Domain.Interfaces
{
    public interface ISolutionAnalyzer
    {
        public Task<AnalyzedSolution> AnalyzeSolutionAsync(Solution solution);
    }
}
