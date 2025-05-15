using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;
using Solution = CodeAssistant.Domain.Models.Solution;

namespace CodeAssistant.Application.Interfaces
{
    public interface ISolutionBuilderService
    {
        public Task<Solution> CompileAsync(SolutionReference solutionReference);
    }
}
