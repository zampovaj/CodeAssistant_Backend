using CodeAssistant.API.DTOs;

namespace CodeAssistant.Application.Interfaces
{
    public interface IWindowsAnalyzerClient
    {
        Task<AnalyzeSolutionResponseDto> ForwardToWindowsAsync(byte[] zipFile);
    }
}
