using CodeAssistant.API.DTOs;
using CodeAssistant.Application.Interfaces;
using System.Text.Json;

namespace CodeAssistant.Infrastructure.ApplicationServices
{
    public class WindowsAnalyzerClient : IWindowsAnalyzerClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public WindowsAnalyzerClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<AnalyzeSolutionResponseDto> ForwardToWindowsAsync(byte[] zipFile)
        {
            var content = new ByteArrayContent(zipFile);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            var request = new HttpRequestMessage(HttpMethod.Post,
                _config["WindowsBackend:Url"])
            {
                Content = content
            };

            var apiKey = Environment.GetEnvironmentVariable("ANALYZER_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
                throw new Exception("ANALYZER_API_KEY environment variable is not set.");

            request.Headers.Add("X-API-KEY", apiKey);

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Windows backend returned {(int)response.StatusCode}: {await response.Content.ReadAsStringAsync()}");

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AnalyzeSolutionResponseDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}