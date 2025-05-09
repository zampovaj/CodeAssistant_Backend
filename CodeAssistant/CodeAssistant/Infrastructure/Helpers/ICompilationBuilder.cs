using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Helpers
{
    public interface ICompilationBuilder
    {
        public Compilation Build(SyntaxTree syntaxTree);
    }
}
