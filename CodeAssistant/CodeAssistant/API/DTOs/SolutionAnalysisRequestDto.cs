namespace CodeAssistant.API.DTOs
{
    public class SolutionAnalysisRequestDto
    {
        public IFormFile ZipFile { get; set; }
        public SolutionAnalysisRequestDto(IFormFile zipFile)
        {
            ZipFile = zipFile;
        }
    }
}
