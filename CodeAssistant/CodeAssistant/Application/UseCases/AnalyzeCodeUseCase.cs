using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using System;

namespace CodeAssistant.Application.UseCases
{
    /// <summary>
    /// Use case for analyzing a code snippet and returning a collection of detected code errors.
    /// </summary>
    public class AnalyzeCodeUseCase
    {
        private readonly ICodeAnalyzer _codeAnalyzer;
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeCodeUseCase"/> class.
        /// </summary>
        /// <param name="codeAnalyzer">
        /// The code analyzer implementation used to process code and detect errors.
        /// </param>
        public AnalyzeCodeUseCase(ICodeAnalyzer codeAnalyzer)
        {
            _codeAnalyzer = codeAnalyzer;
        }

        /// <summary>
        /// Executes the code analysis on the provided code snippet.
        /// </summary>
        /// <param name="snippet">The <see cref="CodeSnippet"/> to analyze.</param>
        /// <returns>
        /// A read-only collection of <see cref="CodeError"/> representing the issues found in the code.
        /// </returns>
        public IReadOnlyCollection<CodeError> Execute(CodeSnippet snippet)
        {
            return _codeAnalyzer.Analyze(snippet);
        }
    }
}