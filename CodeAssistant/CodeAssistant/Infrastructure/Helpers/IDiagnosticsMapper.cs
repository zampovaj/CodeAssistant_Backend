using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Defines a contract for mapping Roslyn <see cref="Diagnostic"/> instances to domain-specific <see cref="CodeError"/> models.
    /// </summary>
    public interface IDiagnosticsMapper
    {
        /// <summary>
        /// Maps a collection of <see cref="Diagnostic"/> objects to domain-level <see cref="CodeError"/> instances.
        /// </summary>
        /// <param name="diagnostics">The diagnostics to map.</param>
        /// <returns>A read-only collection of <see cref="CodeError"/> instances.</returns>
        IReadOnlyCollection<CodeError> Map(IEnumerable<Diagnostic> diagnostics);
    }

}
