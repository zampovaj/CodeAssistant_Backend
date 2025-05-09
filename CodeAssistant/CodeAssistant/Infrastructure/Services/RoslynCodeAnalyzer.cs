using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using CodeAssistant.Infrastructure.Helpers;

namespace CodeAssistant.Infrastructure.Services
{
    public class RoslynCodeAnalyzer : ICodeAnalyzer
    {
        private readonly ISyntaxParser _syntaxParser;
        private readonly ICompilationBuilder _compilationBuilder;
        private readonly IDiagnosticsMapper _diagnosticsMapper;
        public RoslynCodeAnalyzer(ISyntaxParser syntaxParser,
            ICompilationBuilder compilationBuilder,
            IDiagnosticsMapper diagnosticsMapper)
        {
            _syntaxParser = syntaxParser;
            _compilationBuilder = compilationBuilder;
            _diagnosticsMapper = diagnosticsMapper;
        }

        public Task<IReadOnlyCollection<CodeError>> AnalyzeAsync(CodeSnippet codeSnippet)
        {
            var syntaxTree = _syntaxParser.Parse(codeSnippet.Code);
            var compilation = _compilationBuilder.Build(syntaxTree);
            var diagnostics = compilation.GetDiagnostics();
            var codeErrors = _diagnosticsMapper.Map(diagnostics);
            return Task.FromResult(codeErrors);
        }
    }
}
