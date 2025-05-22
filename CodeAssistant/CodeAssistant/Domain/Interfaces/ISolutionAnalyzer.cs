using CodeAssistant.Domain.Models;

namespace CodeAssistant.Domain.Interfaces
{
    /// <summary>
    /// Analyzed solution for errors.
    /// </summary>
    public interface ISolutionAnalyzer
    {
        /// <summary>
        /// Asnychronous method which detects errors in solution and returns them as part of <see cref="AnalyzedSolution"/> model
        /// </summary>
        /// <param name="solution">Solution to be analyzed</param>
        /// <returns><see cref="AnalyzedSolution"/> containing analyzed projects with collections of errors.</returns>
        public Task<AnalyzedSolution> AnalyzeSolutionAsync(Solution solution);
    }
}
