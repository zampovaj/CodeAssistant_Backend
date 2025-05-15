namespace CodeAssistant.API.DTOs
{
    /// <summary>
    /// Represents the severity level of a code analysis issue.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Informational message, not necessarily a problem.
        /// </summary>
        Info,

        /// <summary>
        /// A warning that may indicate a potential issue or bad practice.
        /// </summary>
        Warning,

        /// <summary>
        /// A critical issue that indicates invalid or erroneous code.
        /// </summary>
        Error
    }


    /// <summary>
    /// Data Transfer Object representing the result of a code analysis.
    /// </summary>
    public class AnalyzeCodeResponseDto
    {
        /// <summary>
        /// A list of errors and warnings found in the analyzed code.
        /// </summary>
        public List<CodeErrorDto> Errors { get; } = new();

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeCodeResponseDto"/>.
        /// </summary>
        /// <param name="errors">The list of code errors returned by the analysis.</param>
        public AnalyzeCodeResponseDto(List<CodeErrorDto> errors)
        {
            Errors = errors;
        }
    }

    /// <summary>
    /// Represents a single issue (error, warning, or info) found in the source code.
    /// </summary>
    public class CodeErrorDto
    {
        /// <summary>
        /// The line number in the source code where the issue was found.
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// A human-readable description of the issue.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// The code or identifier of the issue (e.g., CS1001, CA2000).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The type of the issue (Info, Warning, or Error).
        /// </summary>
        public ErrorType Type { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="CodeErrorDto"/>.
        /// </summary>
        /// <param name="line">The line number where the issue occurred. Must be > 0.</param>
        /// <param name="message">A description of the issue.</param>
        /// <param name="code">The identifier of the issue.</param>
        /// <param name="type">The severity of the issue.</param>
        public CodeErrorDto(int line, string message, string code, ErrorType type)
        {
            Line = line;
            Message = message;
            Code = code;
            Type = type;
        }
    }
}
