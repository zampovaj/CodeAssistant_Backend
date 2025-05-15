namespace CodeAssistant.API.DTOs
{
    /// <summary>
    /// Data Transfer Object representing a code analysis request.
    /// </summary>
    public class AnalyzeCodeRequestDto
    {
        private const int maxCodeLength = 10_000;

        /// <summary>
        /// The source code to be analyzed.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeCodeRequestDto"/>.
        /// </summary>
        /// <param name="code">The code to analyze.</param>
        public AnalyzeCodeRequestDto(string code)
        {
            Code = code;
        }
    }
}
