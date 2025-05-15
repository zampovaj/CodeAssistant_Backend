namespace CodeAssistant.API.DTOs
{
    /// <summary>
    /// Data Transfer Object representing a solution analysis request.
    /// </summary>
    public class AnalyzeSolutionRequestDto
    {
        /// <summary>
        /// The solution.zip file to be analyzed.
        /// </summary>
        public IFormFile ZipFile { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeSolutionRequestDto"/>.
        /// </summary>
        /// <param name="zipFile">The solution file to analyze.</param>
        public AnalyzeSolutionRequestDto(IFormFile zipFile)
        {
            ZipFile = zipFile;
        }
    }
}
