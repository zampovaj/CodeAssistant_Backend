using CodeAssistant.Application.Interfaces;
using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;
using Analyzer.Core.Infrastructure.Helpers;

namespace CodeAssistant.Infrastructure.ApplicationServices
{
    /// <summary>
    /// Uses <see cref="ISyntaxParser"/> and <see cref="ICompilationBuilder"/> to build compilation from <see cref="CodeSnippet"/>
    /// </summary>
    public class CodeCompilationBuilderService : ICodeCompilationBuilderService
    {
        private readonly ISyntaxParser _parser;
        private readonly ICompilationBuilder _compilationBuilder;

        /// <summary>
        /// Initializes an instance of <see cref="CodeCompilationBuilderService"/>
        /// </summary>
        /// <param name="parser">Used for converting <see cref="CodeSnippet"/> to <see cref="SyntaxTree"/></param>
        /// <param name="compilationBuilder">Used for converting <see cref="SyntaxTree"/> to <see cref="Compilation"/></param>
        public CodeCompilationBuilderService(ISyntaxParser parser, ICompilationBuilder compilationBuilder)
        {
            _parser = parser;
            _compilationBuilder = compilationBuilder;
        }

        /// <summary>
        /// Asynchronous method that converts <see cref="CodeSnippet"/> to <see cref="Compilation"/>
        /// </summary>
        /// <param name="codeSnippet"></param>
        /// <returns>Task with compilation of submitted code snippet inside</returns>
        public async Task<Compilation> CreateCompilationAsync(CodeSnippet codeSnippet)
        {
            var syntaxTree =  _parser.Parse(codeSnippet.Code);
            return _compilationBuilder.Build(syntaxTree);
        }
    }
}
