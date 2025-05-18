namespace CodeAssistant.Application.Interfaces
{
    public interface IZipHandler
    {
        Task<string> GetPathAsync(IFormFile zipFile);
    }
}
