namespace CodeAssistant.Infrastructure.Helpers
{
    public interface IZipExtractor
    {
        Task<string> SaveAndExtractAsync(IFormFile zipFile);
    }
}
