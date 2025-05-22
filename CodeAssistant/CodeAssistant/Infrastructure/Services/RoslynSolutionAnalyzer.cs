using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

using Solution = CodeAssistant.Domain.Models.Solution;
using Project = CodeAssistant.Domain.Models.Project;
namespace CodeAssistant.Infrastructure.Services
{
    /// <summary>
    /// Accepts <see cref="Solution"/>, analyzes it for errors, maps it to domain model and returns <see cref="AnalyzedSolution"/>.
    /// </summary>
    public class RoslynSolutionAnalyzer : ISolutionAnalyzer
    {
        /// <summary>
        /// Code analyzer, analyzes the compilation and returns collection of errors.
        /// </summary>
        private readonly ICodeAnalyzer _codeAnalyzer;
        
        /// <summary>
        /// Initializes a new instance of <see cref="RoslynSolutionAnalyzer"/>.
        /// </summary>
        /// <param name="codeAnalyzer">Code analyzer to be used for diagnostics.</param>
        public RoslynSolutionAnalyzer(ICodeAnalyzer codeAnalyzer)
        {
            _codeAnalyzer = codeAnalyzer;
        }
        /// <summary>
        /// Accepts <see cref="Solution"/>, goes through each <see cref="Project"/> in solution,
        /// retrieves its diagnostics, maps them onto <see cref="AnalyzedProject"/> 
        /// and adds each project into <see cref="AnalyzedSolution"/>.
        /// </summary>
        /// <param name="solution">solution to be analyzed.</param>
        /// <returns><see cref="AnalyzedSolution"/> with porjects containing the results of code analysis.</returns>
        public async Task<AnalyzedSolution> AnalyzeSolutionAsync(Solution solution)
        {
            AnalyzedSolution analyzedSolution = new();
            foreach (var project in solution.Projects)
            {
                analyzedSolution.AddProject(
                    new AnalyzedProject(project.ProjectCompilation.AssemblyName,
                    await _codeAnalyzer.AnalyzeAsync(project.ProjectCompilation)));
            }
            return analyzedSolution;
        }
    }
}
