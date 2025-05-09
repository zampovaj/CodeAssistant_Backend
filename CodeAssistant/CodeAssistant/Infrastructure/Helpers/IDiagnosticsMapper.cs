using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Helpers
{
    public interface IDiagnosticsMapper
    {
        IReadOnlyCollection<CodeError> Map(IEnumerable<Diagnostic> diagnostics);
    }
}
