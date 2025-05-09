using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeAssistant.Infrastructure.Helpers
{
    public interface ISyntaxParser
    {
        SyntaxTree Parse(string code);
    }
}
