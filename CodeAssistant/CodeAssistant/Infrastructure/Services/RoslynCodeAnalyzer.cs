using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using CodeAssistant.Infrastructure.Helpers;

namespace CodeAssistant.Infrastructure.Services
{
    /// <summary>
    /// Provides Roslyn-based code analysis functionality.
    /// Parses code, compiles it, retrieves diagnostics, and maps them to domain-specific code errors.
    /// </summary>
    public class RoslynCodeAnalyzer : ICodeAnalyzer
    {
        private readonly ISyntaxParser _syntaxParser;
        private readonly ICompilationBuilder _compilationBuilder;
        private readonly IDiagnosticsMapper _diagnosticsMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoslynCodeAnalyzer"/> class.
        /// </summary>
        /// <param name="syntaxParser">Responsible for parsing code into a Roslyn SyntaxTree.</param>
        /// <param name="compilationBuilder">Builds a Roslyn Compilation from the syntax tree.</param>
        /// <param name="diagnosticsMapper">Maps Roslyn diagnostics to domain-specific <see cref="CodeError"/> instances.</param>
        public RoslynCodeAnalyzer(
            ISyntaxParser syntaxParser,
            ICompilationBuilder compilationBuilder,
            IDiagnosticsMapper diagnosticsMapper)
        {
            _syntaxParser = syntaxParser;
            _compilationBuilder = compilationBuilder;
            _diagnosticsMapper = diagnosticsMapper;
        }

        /// <inheritdoc />
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
