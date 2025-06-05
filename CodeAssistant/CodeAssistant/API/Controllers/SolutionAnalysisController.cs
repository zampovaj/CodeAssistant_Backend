using CodeAssistant.API.DTOs;
using CodeAssistant.API.Mappers;
using CodeAssistant.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using CodeAssistant.Application.Interfaces;
using Microsoft.Build.Tasks;
using System.Diagnostics;
using Analyzer.Core.Application.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace CodeAssistant.API.Controllers
{
    /// <summary>
    /// Controller for analyzing C# solution and returning diagnostic results.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionAnalysisController : ControllerBase
    {
        private readonly AnalyzeSolutionUseCase _analyzeSolutionUseCase;
        private readonly IZipHandler _zipHandler;
        private readonly IWindowsAnalyzerClient _windowsAnalyzer;
        private readonly ITargetFrameworkDetector _frameworkDetector;

        /// <summary>
        /// Initializes a new instance of the <see cref=SolutionAnalysisController"/> class.
        /// </summary>
        /// <param name="analyzeSolutionUseCase">The use case responsible for analyzing solutions.</param>
        /// <param name="zipHandler">The service responsible for saving and etracting zip file</param>
        public SolutionAnalysisController(AnalyzeSolutionUseCase analyzeSolutionUseCase,
            IZipHandler zipHandler,
            IWindowsAnalyzerClient windowsAnalyzer,
            ITargetFrameworkDetector frameworkDetector)
        {
            _analyzeSolutionUseCase = analyzeSolutionUseCase;
            _zipHandler = zipHandler;
            _windowsAnalyzer = windowsAnalyzer;
            _frameworkDetector = frameworkDetector;
        }

        /// <summary>
        /// Analyzes the provided C# solution for compilation errors and warnings.
        /// Accepts .zip file containing C# solution
        /// </summary>
        /// <param name="zipFile">The <see cref="IFormFile" .zip file containing solution for analysis./></param>
        /// <returns>
        /// A <see cref="AnalyzeSolutionResponseDto"/> containing the list of detected errors and warnings.
        /// Returns 400 Bad Request if input is null or if 
        /// </returns>
        /// <exception cref="Exception">If any exception ocurres, returns bad request containing the exception message</exception>
        [HttpPost("analyze")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> AnalyzeSolutionAsync([FromForm] IFormFile zipFile)
        {
            try
            {
                if (zipFile == null || zipFile.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }
                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await zipFile.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                var solutionPath = await _zipHandler.GetPathAsync(fileBytes);
                if (solutionPath == null)
                {
                    return BadRequest("No solution found in zip.");
                }

                // windows detection
                bool isWindowsOnly = await _frameworkDetector.IsWindowsOnlyAsync(solutionPath);

                if (isWindowsOnly)
                {
                    try
                    {
                        var forwardedResponse = await _windowsAnalyzer.ForwardToWindowsAsync(fileBytes);
                        return Ok(forwardedResponse);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(502, $"Failed to analyze on Windows backend {ex.Message}");
                    }
                }

                var solution = AnalyzeSolutionMapper.ToModel(solutionPath);
                var result = await _analyzeSolutionUseCase.ExecuteAsync(solution);
                var response = AnalyzeSolutionMapper.ToDto(result);

                return Ok(response);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Exception ocurred during analysis: {ex.Message}");
            }
        }


    }
}
