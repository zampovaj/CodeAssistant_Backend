using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using Microsoft.CodeAnalysis;
using System;
using CodeAssistant.Application.Interfaces;

namespace CodeAssistant.Application.UseCases
{
    /// <summary>
    /// Use case for analyzing a code snippet and returning a collection of detected code errors.
    /// </summary>
    public class AnalyzeCodeUseCase
    {
        private readonly ICodeCompilationBuilderService _codeCompilationBuilder;
        private readonly ICodeAnalyzer _analyzer;
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeCodeUseCase"/> class.
        /// </summary>
        /// <param name="codeAnalyzer">
        /// The code analyzer implementation used to process code and detect errors.
        /// </param>
        public AnalyzeCodeUseCase(ICodeCompilationBuilderService codeCompilationBuilder, ICodeAnalyzer analyzer)
        {
            _codeCompilationBuilder = codeCompilationBuilder;
            _analyzer = analyzer;
        }

        /// <summary>
        /// Executes the code analysis on the provided code snippet.
        /// </summary>
        /// <param name="snippet">The <see cref="CodeSnippet"/> to analyze.</param>
        /// <returns>
        /// A read-only collection of <see cref="CodeError"/> representing the issues found in the code.
        /// </returns>
        public async Task<IReadOnlyCollection<CodeError>> ExecuteAsync(CodeSnippet codeSnippet)
        {
            var compilation = await _codeCompilationBuilder.CreateCompilationAsync(codeSnippet);
            return await _analyzer.AnalyzeAsync(compilation);
        }
    }
}