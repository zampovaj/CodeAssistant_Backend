using CodeAssistant.Application.Interfaces;
using CodeAssistant.Domain.Models;
using System;
using Analyzer.Core.Infrastructure.Services;
using Analyzer.Core.Domain.Interfaces;
using Analyzer.Core.Application.Interfaces;

namespace CodeAssistant.Application.UseCases
{
    /// <summary>
    /// Use case for analyzing a solution and returning a collection of detected code errors for each project.
    /// </summary>
    public class AnalyzeSolutionUseCase
    {
        private readonly ISolutionAnalyzer _solutionAnalyzer;
        private readonly ISolutionBuilderService _solutionBuilderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeSolutionUseCase"/> class.
        /// </summary>
        /// <param name="solutionAnalyzer">
        /// The solution analyzer implementation used to process code and detect errors.
        /// </param>
        public AnalyzeSolutionUseCase(ISolutionAnalyzer solutionAnalyzer, ISolutionBuilderService solutionBuilderService)
        {
            _solutionAnalyzer = solutionAnalyzer;
            _solutionBuilderService = solutionBuilderService;
        }

        /// <summary>
        /// Asnychronous mehtod, that executes the solution analysis on the provided solution.
        /// </summary>
        /// <param name="solutionReference">The <see cref="SolutionReference"/> to analyze.</param>
        /// <returns>
        /// An <see cref="AnalyzedSolution"/> containing collection of projects with collections of code errors.
        /// </returns>
        public async Task<AnalyzedSolution> ExecuteAsync(SolutionReference solutionReference)
        {
            Solution solution = await _solutionBuilderService.CompileAsync(solutionReference);
            return await _solutionAnalyzer.AnalyzeSolutionAsync(solution);
        }
    }
}