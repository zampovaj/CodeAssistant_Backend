using Microsoft.CodeAnalysis.CSharp;


namespace CodeAssistant.Domain.Models
{
    /// <summary>
    /// Represents the project to be analyzed.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Compilation of the project.
        /// </summary>
        public CSharpCompilation ProjectCompilation { get; set; }
        /// <summary>
        /// Initializes an instance of <see cref="Project"/> class.
        /// </summary>
        /// <param name="projectCompilation">The compilation of the project.</param>
        public Project(CSharpCompilation projectCompilation)
        {
            ProjectCompilation = projectCompilation;
        }
    }
}
