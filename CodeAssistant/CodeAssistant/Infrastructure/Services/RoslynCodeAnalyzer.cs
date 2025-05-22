using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using CodeAssistant.Infrastructure.Helpers;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Services
{
    /// <summary>
    /// Provides Roslyn-based code analysis functionality.
    /// Accepts compilation, retrieves diagnostics, and maps them to domain-specific code errors.
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
        /// <summary>
        /// Retrives diagnostics information about accepted compilation using Roslyn.
        /// Uses <see cref="IDiagnosticsMapper"/> to map the results to a collection of <see cref="CodeError"/>
        /// Runs asynchronously.
        /// </summary>
        /// <param name="compilation">Compilation to be analyzed</param>
        /// <returns>A <see cref="Task"/> containing a readonly collection of <see cref="CodeError"/>.</returns>
        public Task<IReadOnlyCollection<CodeError>> AnalyzeAsync(Compilation compilation)
        {
            var diagnostics = compilation.GetDiagnostics();
            var codeErrors = _diagnosticsMapper.Map(diagnostics);
            return Task.FromResult(codeErrors);
        }
    }

}
