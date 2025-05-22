using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Domain.Interfaces
{
    /// <summary>
    /// Analyzes code for errors.
    /// </summary>
    public interface ICodeAnalyzer
    {
        /// <summary>
        /// Asnychronous method which detects errors in code nd returns them as a collection
        /// </summary>
        /// <param name="codeSnippet">Code snippet to be analyzed</param>
        /// <returns>A collection of <see cref="CodeError"/> errors</returns>
        Task<IReadOnlyCollection<CodeError>> AnalyzeAsync(Compilation compilation);
    }
}
