namespace CodeAssistant.API.DTOs
{


    /// <summary>
    /// Data Transfer Object representing the result of a code analysis.
    /// </summary>
    public class AnalyzeCodeResponseDto
    {
        /// <summary>
        /// A list of <see cref="CodeErrorDto"/> errors and warnings found in the analyzed code.
        /// </summary>
        public List<CodeErrorDto> Errors { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeCodeResponseDto"/>.
        /// </summary>
        /// <param name="errors">The list of code errors returned by the analysis.</param>
        public AnalyzeCodeResponseDto(List<CodeErrorDto> errors)
        {
            Errors = errors;
        }
    }
}
