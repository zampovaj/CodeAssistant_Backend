

namespace CodeAssistant.API.DTOs
{
    public enum ErrorType
    {
        Info,
        Warning,
        Error
    }
    public class AnalyzeCodeRequestDto
    {
        private const int maxCodeLength = 10_000;

        public string Code { get; }

        public AnalyzeCodeRequestDto(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code));
            if (code.Length > maxCodeLength)
                throw new ArgumentException($"Code is too long, maximum allowed length is {maxCodeLength}.");
            Code = code;
        }
    }
    public class AnalyzeCodeResponseDto
    {
        public List<CodeErrorDto> Errors { get; } = new();
        public AnalyzeCodeResponseDto(List<CodeErrorDto> errors)
        {
            Errors = errors;
        }
    }

    public class CodeErrorDto
    {
        public int Line { get; }
        public string Message { get; }
        public string Code { get; }
        public ErrorType Type { get; } // warning, error,...

        public CodeErrorDto(int line, string message, string code, ErrorType type)
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
