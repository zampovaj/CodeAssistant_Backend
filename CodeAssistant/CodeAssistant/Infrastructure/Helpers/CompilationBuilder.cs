using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeAssistant.Infrastructure.Helpers
{
    public class CompilationBuilder : ICompilationBuilder
    {
        public Compilation Build(SyntaxTree syntaxTree)
        {
            var references = new[]
            { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) };
            return
                CSharpCompilation.Create("CodeAnalysis")
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTree);
        }
    }
}
