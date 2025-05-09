using CodeAssistant.API.DTOs;
using CodeAssistant.API.Mappers;
using CodeAssistant.Application.UseCases;
using CodeAssistant.Domain.Models;
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
        /// Accepts json.
        /// </summary>
        /// <param name="request">The request containing the code to analyze.</param>
        /// <returns>A response containing the list of errors found in the code.</returns>
        [HttpPost("analyze/json")]
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
        /// <summary>
        /// Analyzes the provided code snippet for errors.
        /// Accepts plain text
        /// </summary>
        /// <param name="code">The string containing the code to analyze.</param>
        /// <returns>A response containing the list of errors found in the code.</returns>
        [HttpPost("analyze/plain")]
        [Consumes("text/plain; charset=UTF-8")]
        public async Task<ActionResult<AnalyzeCodeResponseDto>> AnalyzeCodeAsync([FromBody] string code)
        {
            if (code == null)
            {
                return BadRequest("Invalid request data.");
            }

            var codeSnippet = new CodeSnippet(code);
            var errors = await _analyzeCodeUseCase.ExecuteAsync(codeSnippet);
            var response = AnalyzeCodeMapper.ToDto(errors);

            return Ok(response);
        }
    }
}
