using CodeAssistant.Application.Interfaces;
using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Domain.Models;
using System;

namespace CodeAssistant.Application.UseCases
{
    /// <summary>
    /// Use case for analyzing a solution and returning a collection of detected code errors for each project.
    /// </summary>
    public class AnalyzeSolutionUseCase
    {
        private readonly ISolutionAnalyzer _solutionAnalyzer;
        private readonly ISolutionBuilderService _solutionBuilderService;

        public AnalyzeSolutionUseCase(ISolutionAnalyzer solutionAnalyzer, ISolutionBuilderService solutionBuilderService)
        {
            _solutionAnalyzer = solutionAnalyzer;
            _solutionBuilderService = solutionBuilderService;
        }
        public async Task<AnalyzedSolution> ExecuteAsync(SolutionReference solutionReference)
        {
            Solution solution = await _solutionBuilderService.CompileAsync(solutionReference);
            return await _solutionAnalyzer.AnalyzeSolutionAsync(solution);
        }
    }
}