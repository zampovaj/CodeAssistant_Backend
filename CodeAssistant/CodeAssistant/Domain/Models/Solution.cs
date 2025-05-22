using Newtonsoft.Json.Linq;
using System.Text;

namespace CodeAssistant.Domain.Models
{
    /// <summary>
    /// Represents the solution to be analyzed.
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// List of <see cref="Project"/> which are part of the solutioin.
        /// </summary>
        private List<Project> _projects = new List<Project>(); // initialized to empty to be able to add porjects one by one
        /// <summary>
        /// Public readonly collection of <see cref="Project"/>, represents <see cref="_projects"/>.
        /// </summary>
        public IReadOnlyCollection<Project> Projects { get { return _projects; } }

        /// <summary>
        /// String representation of <see cref="Solution"/>.
        /// </summary>
        /// <returns>A string where each line represents one project name.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var project in _projects)
            {
                sb.AppendLine(project.ProjectCompilation.AssemblyName);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Adds a single project to the <see cref="_projects"/> list.
        /// </summary>
        /// <param name="project">Project to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if project is null or empty.</exception>
        public void AddProject(Project project)
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
        public void AddProjects(IReadOnlyCollection<Project> projects)
        {
            if (projects == null)
                throw new ArgumentNullException(nameof(projects));
            projects.ToList().ForEach(project => AddProject(project));
        }
    }
}
