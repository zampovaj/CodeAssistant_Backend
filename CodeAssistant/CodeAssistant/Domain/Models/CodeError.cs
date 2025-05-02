namespace CodeAssistant.Domain.Models
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
    /// Represents a single issue (error, warning, or info) found in the source code.
    /// </summary>
    public class CodeError
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
        /// Initializes a new instance of <see cref="CodeError"/>.
        /// </summary>
        /// <param name="line">The line number where the issue occurred. Must be > 0.</param>
        /// <param name="message">A description of the issue.</param>
        /// <param name="code">The identifier of the issue.</param>
        /// <param name="type">The severity of the issue.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if line is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown if message or code is null or whitespace.</exception>
        /// <exception cref="ArgumentException">Thrown if the error type is not a defined value.</exception>
        public CodeError(int line, string message, string code, ErrorType type)
        {
            if (line < 1)
                throw new ArgumentOutOfRangeException(nameof(line), "Line number must be greater than 0");
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code), "Code cannot be empty.");
            if (!Enum.IsDefined(typeof(ErrorType), type))
                throw new ArgumentException("Type has to be valid", nameof(type));
            Line = line;
            Message = message;
            Code = code;
            Type = type;
        }
    }
}
