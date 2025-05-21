namespace CodeAssistant.API.DTOs
{
    /// <summary>
    /// Represents the severity level of a code analysis issue.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Hidden message, ignored in the analysis.
        /// </summary>
        Hidden,
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
    /// Represents DTO of a single issue (error, warning, or info) found in the source code.
    /// </summary>
    public class CodeErrorDto
    {
        /// <summary>
        /// The path to the error file.
        /// </summary>
        public string Path { get; }
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
        public CodeErrorDto(string path, int line, string message, string code, ErrorType type)
        {
            Path = path;
            Line = line;
            Message = message;
            Code = code;
            Type = type;
        }
    }
}
