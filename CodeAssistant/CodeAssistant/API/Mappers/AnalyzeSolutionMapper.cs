using CodeAssistant.API.DTOs;
using CodeAssistant.Domain.Models;

namespace CodeAssistant.API.Mappers
{
    /// <summary>
    /// Provides methods to map between DTOs and domain models for solution analysis functionality.
    /// This includes transforming incoming API request DTOs to domain models and converting domain results back into API response DTOs.
    /// </summary>
    public static class AnalyzeSolutionMapper
    {

        /// <summary>
        /// Maps a <see cref="AnalyzedSolution"/> domain model to a corresponding <see cref="AnalyzeSolutionResponseDto"/>.
        /// This method is used to convert the results of the solution analysis from the domain model to an API-friendly response.
        /// </summary>
        /// <param name="solution">A <see cref="AnalyzedSolution"/> object representing the whole analyzed solution, with projects and code errors.</param>
        /// <returns>A <see cref="AnalyzeSolutionResponseDto"/> representing the analyzed solution.</returns>
        public static AnalyzeSolutionResponseDto ToDto(AnalyzedSolution solution)
        {
            var projects = new List<ProjectDto>();
            foreach (var project in solution.Projects)
            {
                projects.Add(new ProjectDto(project.Name, project.Errors.Select(e => new CodeErrorDto(e.Path, e.Line, e.Message, e.Code, (DTOs.ErrorType)e.Type)).ToList()));
            }
            return new AnalyzeSolutionResponseDto(projects);

        }
        /// <summary>
        /// Maps the <see cref="string"/> path to solution to the <see cref="SolutionReference"/> domain model.
        /// This is used to convert the result data of extracting and saving the file parsed into api into a model that can be processed by the domain layer.
        /// </summary>
        /// <param name="solutionPath">The path to the locally saved solutioin to be analyzed.</param>
        /// <returns>A <see cref="SolutionReference"/> model containing the path to the solution to be analyzed.</returns>

        public static SolutionReference ToModel(string solutionPath)
        {
            return new SolutionReference(solutionPath);
        }
    }
}
