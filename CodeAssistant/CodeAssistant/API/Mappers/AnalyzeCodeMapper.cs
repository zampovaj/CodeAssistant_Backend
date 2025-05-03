using CodeAssistant.API.DTOs;
using CodeAssistant.Domain.Models;

namespace CodeAssistant.API.Mappers
{
    /// <summary>
    /// Provides methods to map between DTOs and domain models for code analysis functionality.
    /// This includes transforming incoming API request DTOs to domain models and converting domain results back into API response DTOs.
    /// </summary>
    public static class AnalyzeCodeMapper
    {
        /// <summary>
        /// Maps the <see cref="AnalyzeCodeRequestDto"/> to the <see cref="CodeSnippet"/> domain model.
        /// This is used to convert the request data from the API into a model that can be processed by the domain layer.
        /// </summary>
        /// <param name="analyzeCodeRequestDto">The incoming request DTO containing the code snippet to be analyzed.</param>
        /// <returns>A <see cref="CodeSnippet"/> model containing the code to be analyzed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="analyzeCodeRequestDto"/> is null.</exception>
        public static CodeSnippet ToModel(AnalyzeCodeRequestDto analyzeCodeRequestDto)
        {
            return new CodeSnippet(analyzeCodeRequestDto.Code);
        }

        /// <summary>
        /// Maps a list of <see cref="CodeError"/> domain models to a corresponding <see cref="AnalyzeCodeResponseDto"/>.
        /// This method is used to convert the results of the code analysis from the domain model to an API-friendly response.
        /// </summary>
        /// <param name="errors">A list of <see cref="CodeError"/> objects representing the errors found in the code snippet.</param>
        /// <returns>A <see cref="AnalyzeCodeResponseDto"/> containing a list of <see cref="CodeErrorDto"/> for each error found.</returns>
        public static AnalyzeCodeResponseDto ToDto(IReadOnlyCollection<CodeError> errors)
        {
            return new AnalyzeCodeResponseDto(errors.Select(e => new CodeErrorDto(e.Line, e.Message, e.Code, (DTOs.ErrorType)e.Type)).ToList());
        }
    }
}
