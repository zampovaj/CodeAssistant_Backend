using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using CodeAssistant.Infrastructure.Helpers;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Services
{
    /// <summary>
    /// Provides Roslyn-based code analysis functionality.
    /// Parses code, compiles it, retrieves diagnostics, and maps them to domain-specific code errors.
    /// </summary>
    public class RoslynCodeAnalyzer : ICodeAnalyzer
    {
        private readonly IDiagnosticsMapper _diagnosticsMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoslynCodeAnalyzer"/> class.
        /// </summary>
        /// <param name="diagnosticsMapper">Maps Roslyn diagnostics to domain-specific <see cref="CodeError"/> instances.</param>
        public RoslynCodeAnalyzer(IDiagnosticsMapper diagnosticsMapper)
        {
            _diagnosticsMapper = diagnosticsMapper;
        }
        public Task<IReadOnlyCollection<CodeError>> AnalyzeAsync(Compilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            var codeErrors = _diagnosticsMapper.Map(diagnostics);
            return Task.FromResult(codeErrors);
        }
    }

}
