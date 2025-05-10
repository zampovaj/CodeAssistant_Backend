using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Provides functionality to build a Roslyn <see cref="Compilation"/> from a given <see cref="SyntaxTree"/>.
    /// </summary>
    public class CompilationBuilder : ICompilationBuilder
    {
        /// <inheritdoc />
        public Compilation Build(SyntaxTree syntaxTree)
        {
            var references = new[]
            {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
        };

            return CSharpCompilation.Create("CodeAnalysis")
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTree);
        }
    }

}
