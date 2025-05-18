using CodeAssistant.API.DTOs;
using CodeAssistant.API.Mappers;
using CodeAssistant.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using CodeAssistant.Application.Interfaces;
using Microsoft.Build.Tasks;
using System.Diagnostics;

namespace CodeAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionAnalysisController : ControllerBase
    {
        private AnalyzeSolutionUseCase _analyzeSolutionUseCase;
        private readonly IZipHandler _zipHandler;

        public SolutionAnalysisController(AnalyzeSolutionUseCase analyzeSolutionUseCase, IZipHandler zipHandler)
        {
            _analyzeSolutionUseCase = analyzeSolutionUseCase;
            _zipHandler = zipHandler;
        }

        [HttpPost("analyze")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> AnalyzeSolutionAsync([FromForm] IFormFile zipFile)
        {
            if (zipFile == null || zipFile.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            var solutionPath = await _zipHandler.GetPathAsync(zipFile);
            if (solutionPath == null)
            {
                return BadRequest("No solution found in zip.");
            }

            var solution = AnalyzeSolutionMapper.ToModel(solutionPath);
            var result = await _analyzeSolutionUseCase.ExecuteAsync(solution);

            return Ok(result);
        }


    }
}
