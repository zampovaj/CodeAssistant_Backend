using CodeAssistant.API.DTOs;
using CodeAssistant.API.Mappers;
using CodeAssistant.Application.UseCases;
using CodeAssistant.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeAssistant.API.Controllers
{
    /// <summary>
    /// Controller for analyzing C# code snippets and returning diagnostic results.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CodeAnalysisController : ControllerBase
    {
        private readonly AnalyzeCodeUseCase _analyzeCodeUseCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeAnalysisController"/> class.
        /// </summary>
        /// <param name="analyzeCodeUseCase">The use case responsible for analyzing code snippets.</param>
        public CodeAnalysisController(AnalyzeCodeUseCase analyzeCodeUseCase)
        {
            _analyzeCodeUseCase = analyzeCodeUseCase;
        }

        /// <summary>
        /// Analyzes the provided C# code snippet for compilation errors and warnings.
        /// Accepts JSON-encoded code input.
        /// </summary>
        /// <param name="request">The request object containing the code to analyze.</param>
        /// <returns>
        /// A response DTO containing the list of detected errors and warnings.
        /// Returns 400 Bad Request if input is null.
        /// </returns>
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
        /// Analyzes the provided C# code snippet for compilation errors and warnings.
        /// Accepts plain text input.
        /// </summary>
        /// <param name="code">The raw string of code to analyze.</param>
        /// <returns>
        /// A response DTO containing the list of detected errors and warnings.
        /// Returns 400 Bad Request if input is null.
        /// </returns>
        [HttpPost("analyze/plain")]
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
