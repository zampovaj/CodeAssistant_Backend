using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeAssistant.Infrastructure.Helpers
{
    public class SyntaxParser : ISyntaxParser
    {
        public SyntaxTree Parse(string code)
        {
            return CSharpSyntaxTree.ParseText(code);
        }
    }
}
