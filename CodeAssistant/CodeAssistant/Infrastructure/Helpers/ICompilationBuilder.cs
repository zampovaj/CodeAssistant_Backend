using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.Helpers
{
    public interface ICompilationBuilder
    {
        public Compilation CompilationBuilder(SyntaxTree syntaxTree);
    }
}
