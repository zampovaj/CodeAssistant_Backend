using CodeAssistant.API.DTOs;
using CodeAssistant.API.Mappers;
using CodeAssistant.Application.Interfaces;
using CodeAssistant.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeAnalysisController : ControllerBase
    {
        private readonly ICodeAnalyzer _codeAnalyzer;

        public CodeAnalysisController(ICodeAnalyzer codeAnalyzer)
        {
            _codeAnalyzer = codeAnalyzer;
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
            var errors = _codeAnalyzer.Analyze(codeSnippet);
            var response = AnalyzeCodeMapper.ToDto(errors);
            
            return Ok(response);
        }
    }
}
