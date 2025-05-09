using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Provides functionality for mapping Roslyn <see cref="Diagnostic"/> instances to domain-level <see cref="CodeError"/> representations.
    /// </summary>
    public class DiagnosticsMapper : IDiagnosticsMapper
    {
        /// <summary>
        /// Maps a collection of <see cref="Diagnostic"/> objects to a read-only collection of <see cref="CodeError"/> objects.
        /// </summary>
        /// <param name="diagnostics">The diagnostics to map. Must not be null.</param>
        /// <returns>A read-only collection of <see cref="CodeError"/> objects representing the mapped diagnostics.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="diagnostics"/> parameter is <c>null</c>.</exception>
        public IReadOnlyCollection<CodeError> Map(IEnumerable<Diagnostic> diagnostics)
        {
            if (diagnostics == null)
                throw new ArgumentNullException(nameof(diagnostics));

            return diagnostics
                .Where(d => d.Location != Location.None && d.Location.IsInSource)
                .Select(d => new CodeError(
                    line: d.Location.GetLineSpan().StartLinePosition.Line + 1,
                    message: d.GetMessage(),
                    code: d.Id,
                    type: MapSeverityToErrorType(d.Severity)))
                .ToList();
        }

        /// <summary>
        /// Maps a <see cref="DiagnosticSeverity"/> to the corresponding <see cref="ErrorType"/>.
        /// </summary>
        /// <param name="severity">The severity level of the diagnostic.</param>
        /// <returns>The mapped <see cref="ErrorType"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <paramref name="severity"/> is not recognized.</exception>
        private ErrorType MapSeverityToErrorType(DiagnosticSeverity severity)
        {
            return severity switch
            {
                DiagnosticSeverity.Info => ErrorType.Info,
                DiagnosticSeverity.Warning => ErrorType.Warning,
                DiagnosticSeverity.Error => ErrorType.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(severity), "Unexpected diagnostic severity")
            };
        }
    }
}
