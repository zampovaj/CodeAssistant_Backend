using CodeAssistant.Domain.Models;

namespace CodeAssistant.API.DTOs
{
    public class AnalyzeSolutionResponseDto
    {
        public IReadOnlyCollection<ProjectDto> Projects { get; } = new List<ProjectDto>();
        public AnalyzeSolutionResponseDto(IReadOnlyCollection<ProjectDto> projects)
        {
            Projects = projects;
        }
    }

    public class ProjectDto
    {
        public string Name { get; }
        public IReadOnlyCollection<CodeErrorDto> Errors { get; }
        public ProjectDto(string name, IReadOnlyCollection<CodeErrorDto> errors)
        {
            Name = name;
            Errors = errors;
        }
    }
}
