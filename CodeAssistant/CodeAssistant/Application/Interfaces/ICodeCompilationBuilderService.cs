using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Application.Interfaces
{
    public interface ICodeCompilationBuilderService
    {
        public Task<Compilation> CreateCompilationAsync(CodeSnippet codeSnippet);
    }
}
