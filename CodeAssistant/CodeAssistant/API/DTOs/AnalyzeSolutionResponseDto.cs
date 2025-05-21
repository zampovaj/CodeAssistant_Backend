using CodeAssistant.Domain.Models;

namespace CodeAssistant.API.DTOs
{
    /// <summary>
    /// Data Transfer Object representing a solution analysis response.
    /// </summary>
    public class AnalyzeSolutionResponseDto
    {
        /// <summary>
        /// A list of <see cref="ProjectDto"/> projects with errors and warnings found in the analyzed code.
        /// </summary>
        public IReadOnlyCollection<ProjectDto> Projects { get; } = new List<ProjectDto>();


        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeCodeResponseDto"/>.
        /// </summary>
        /// <param name="projects">The DTO representing analyzed projects.</param>
        public AnalyzeSolutionResponseDto(IReadOnlyCollection<ProjectDto> projects)
        {
            Projects = projects;
        }
    }
}
