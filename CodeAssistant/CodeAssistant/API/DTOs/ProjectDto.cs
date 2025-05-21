namespace CodeAssistant.API.DTOs
{
    /// <summary>
    /// Represents a dtaa transfer object containing a single analyzed project name and it's errors.
    /// </summary>
    public class ProjectDto
    {
        /// <summary>
        /// Name of the analyzed project.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// List of <see cref="CodeErrorDto"/> code errors and warnings of the project.
        /// </summary>
        public IReadOnlyCollection<CodeErrorDto> Errors { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="ProjectDto"/>.
        /// </summary>
        /// <param name="name">The name of the analyzed project.</param>
        /// <param name="errors">The list of code errors returned by the analysis.</param>
        public ProjectDto(string name, IReadOnlyCollection<CodeErrorDto> errors)
        {
            Name = name;
            Errors = errors;
        }
    }
}
