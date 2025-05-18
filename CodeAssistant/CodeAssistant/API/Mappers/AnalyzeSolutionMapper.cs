using CodeAssistant.API.DTOs;
using CodeAssistant.Domain.Models;

namespace CodeAssistant.API.Mappers
{
    public static class AnalyzeSolutionMapper
    {
        public static AnalyzeSolutionResponseDto ToDto(AnalyzedSolution solution)
        {
            IReadOnlyCollection<ProjectDto> projects = new List<ProjectDto>();
            foreach (var project in solution.Projects)
            {
                projects.Append(new ProjectDto(project.Name, project.Errors.Select(e => new CodeErrorDto(e.Path, e.Line, e.Message, e.Code, (DTOs.ErrorType)e.Type)).ToList()));
            }
            return new AnalyzeSolutionResponseDto(projects);

        }
        public static SolutionReference ToModel(string solutionPath)
        {
            return new SolutionReference(solutionPath);
        }
    }
}
