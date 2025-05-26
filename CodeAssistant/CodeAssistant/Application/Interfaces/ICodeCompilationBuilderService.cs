using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Application.Interfaces
{
    /// <summary>
    /// Service used to turn code into Compilation, to prepare it for further analysis
    /// </summary>
    public interface ICodeCompilationBuilderService
    {
        /// <summary>
        /// Accepts <see cref="CodeSnippet"/> and converts it to <see cref="Compilation"/>
        /// </summary>
        /// <param name="codeSnippet">Code to be analyzed</param>
        public Task<Compilation> CreateCompilationAsync(CodeSnippet codeSnippet);
    }
}
