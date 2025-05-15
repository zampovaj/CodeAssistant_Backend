using CodeAssistant.Application.Interfaces;
using CodeAssistant.Domain.Models;
using CodeAssistant.Infrastructure.Helpers;
using Microsoft.CodeAnalysis;

namespace CodeAssistant.Infrastructure.ApplicationServices
{
    public class CodeCompilationBuilderService : ICodeCompilationBuilderService
    {
        private readonly ISyntaxParser _parser;
        private readonly ICompilationBuilder _compilationBuilder;
        public CodeCompilationBuilderService(ISyntaxParser parser, ICompilationBuilder compilationBuilder)
        {
            _parser = parser;
            _compilationBuilder = compilationBuilder;
        }

        public async Task<Compilation> CreateCompilationAsync(CodeSnippet codeSnippet)
        {
            var syntaxTree = _parser.Parse(codeSnippet.Code);
            return _compilationBuilder.Build(syntaxTree);
        }
    }
}
