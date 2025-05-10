using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Represents a service for building Roslyn <see cref="Compilation"/> objects.
    /// </summary>
    public interface ICompilationBuilder
    {
        /// <summary>
        /// Builds a <see cref="Compilation"/> from the specified <see cref="SyntaxTree"/>.
        /// </summary>
        /// <param name="syntaxTree">The syntax tree to compile.</param>
        /// <returns>A Roslyn <see cref="Compilation"/> instance.</returns>
        Compilation Build(SyntaxTree syntaxTree);
    }

}
