using CodeAssistant.API.DTOs;
using CodeAssistant.API.Mappers;
using CodeAssistant.Application.UseCases;
using CodeAssistant.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeAnalysisController : ControllerBase
    {
        private readonly AnalyzeCodeUseCase _analyzeCodeUseCase;

        public CodeAnalysisController(AnalyzeCodeUseCase analyzeCodeUseCase)
        {
            _analyzeCodeUseCase = analyzeCodeUseCase;
        }

        /// <summary>
        /// Analyzes the provided code snippet for errors.
        /// </summary>
        /// <param name="request">The request containing the code to analyze.</param>
        /// <returns>A response containing the list of errors found in the code.</returns>
        [HttpPost("analyze")]
        public async Task<ActionResult<AnalyzeCodeResponseDto>> AnalyzeCodeAsync([FromBody] AnalyzeCodeRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var codeSnippet = AnalyzeCodeMapper.ToModel(request);
            var errors = await _analyzeCodeUseCase.ExecuteAsync(codeSnippet);
            var response = AnalyzeCodeMapper.ToDto(errors);
            
            return Ok(response);
        }
    }
}
