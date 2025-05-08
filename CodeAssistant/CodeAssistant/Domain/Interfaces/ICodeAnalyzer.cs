using CodeAssistant.Domain.Models;

namespace CodeAssistant.Domain.Interfaces
{
    public interface ICodeAnalyzer
    {
        /// <summary>
        /// Detects errors in code nd returns them as a collection
        /// </summary>
        /// <param name="codeSnippet">Code snippet to be analyzed</param>
        /// <returns>A collection of <see cref="CodeError"/> errors</returns>
        Task<IReadOnlyCollection<CodeError>> AnalyzeAsync(CodeSnippet codeSnippet);
    }
}
