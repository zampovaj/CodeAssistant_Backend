using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;

namespace CodeAssistant.Infrastructure.Mock
{
    public class MockCodeAnalyzer : ICodeAnalyzer
    {
        public IReadOnlyCollection<CodeError> Analyze(CodeSnippet codeSnippet)
        {
            return new List<CodeError>() { new CodeError(1, "message", "A205", ErrorType.Warning) };
        }
    }
}
