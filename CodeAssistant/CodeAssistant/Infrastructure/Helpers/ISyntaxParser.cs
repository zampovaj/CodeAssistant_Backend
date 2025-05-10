using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Defines a contract for parsing raw C# code into Roslyn syntax trees.
    /// </summary>
    public interface ISyntaxParser
    {
        /// <summary>
        /// Parses raw C# source code into a <see cref="SyntaxTree"/>.
        /// </summary>
        /// <param name="code">The raw C# code to parse.</param>
        /// <returns>A <see cref="SyntaxTree"/> representing the parsed code.</returns>
        SyntaxTree Parse(string code);
    }

}
