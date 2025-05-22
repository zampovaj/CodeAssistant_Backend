namespace CodeAssistant.Domain.Models
{

    /// <summary>
    /// Represents the analyzed solution.
    /// </summary>
    public class AnalyzedSolution
    {
        /// <summary>
        /// List of <see cref="AnalyzedProject"/> analyzed projects.
        /// </summary>
        private List<AnalyzedProject> _projects = new List<AnalyzedProject>();
        /// <summary>
        /// Public readonly collection of <see cref="AnalyzedProject"/>, represents <see cref="_projects"/>.
        /// </summary>
        public IReadOnlyCollection<AnalyzedProject> Projects { get { return _projects; } }

        /// <summary>
        /// Adds a single project to the <see cref="_projects"/> list.
        /// </summary>
        /// <param name="project">Project to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if project is null or empty.</exception>
        public void AddProject(AnalyzedProject project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            _projects.Add(project);
        }
        /// <summary>
        /// Adds a collection of projects to <see cref="_projects"/>.
        /// </summary>
        /// <param name="projects">Projects to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if projects are null or empty.</exception>
        public void AddProjects(IReadOnlyCollection<AnalyzedProject> projects)
        {
            if (projects == null)
                throw new ArgumentNullException(nameof(projects));
            projects.ToList().ForEach(project => AddProject(project));
        }
    }
}
