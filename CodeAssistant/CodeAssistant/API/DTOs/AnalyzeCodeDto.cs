namespace CodeAssistant.API.DTOs
{
    public class AnalyzeCodeRequestDto
    {
        public string Code { get; set; }
    }
    public class AnalyzeCodeResponseDto
    {
        public string Code { get; set; }

    }

    public class CodeErrorDto
    {
        public int Line { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public string Type { get; set; } // warning, error,...
    }

}
