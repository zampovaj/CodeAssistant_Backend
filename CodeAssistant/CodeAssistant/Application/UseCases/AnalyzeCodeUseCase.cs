using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;

namespace CodeAssistant.Application.UseCases
{
    public class AnalyzeCodeUseCase
    {
        private readonly ICodeAnalyzer _codeAnalyzer;
        public AnalyzeCodeUseCase(ICodeAnalyzer codeAnalyzer)
        {
            _codeAnalyzer = codeAnalyzer;
        }

        public IReadOnlyCollection<CodeError> Execute (CodeSnippet snippet)
        {
            return _codeAnalyzer.Analyze(snippet);
        }
    }
}
