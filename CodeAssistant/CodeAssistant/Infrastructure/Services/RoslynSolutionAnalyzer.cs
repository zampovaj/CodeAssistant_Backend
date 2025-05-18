using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

using Solution = CodeAssistant.Domain.Models.Solution;
using Project = CodeAssistant.Domain.Models.Project;
namespace CodeAssistant.Infrastructure.Services
{
    public class RoslynSolutionAnalyzer : ISolutionAnalyzer
    {
        private readonly ICodeAnalyzer _codeAnalyzer;
        
        public RoslynSolutionAnalyzer(ICodeAnalyzer codeAnalyzer)
        {
            _codeAnalyzer = codeAnalyzer;
        }
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
