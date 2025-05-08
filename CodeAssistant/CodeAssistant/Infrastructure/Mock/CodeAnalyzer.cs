using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;

namespace CodeAssistant.Infrastructure.Mock
{
    public class MockCodeAnalyzer : ICodeAnalyzer
    {
        public Task<IReadOnlyCollection<CodeError>> AnalyzeAsync(CodeSnippet codeSnippet)
        {
            return Task.FromResult<IReadOnlyCollection<CodeError>>(
                new List<CodeError> { new CodeError(1, codeSnippet.Code, "A205", ErrorType.Warning) });
        }
    }
}
