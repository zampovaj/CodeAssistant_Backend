using Newtonsoft.Json.Linq;
using System.Text;

namespace CodeAssistant.Domain.Models
{
    public class Solution
    {
        private List<Project> _projects = new List<Project>();
        public IReadOnlyCollection<Project> Projects { get { return _projects; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var project in _projects)
            {
                sb.AppendLine(project.ProjectCompilation.AssemblyName);
            }
            return sb.ToString();
        }

        public void AddProject(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            _projects.Add(project);
        }
        public void AddProjects(IReadOnlyCollection<Project> projects)
        {
            if (projects == null)
                throw new ArgumentNullException(nameof(projects));
            projects.ToList().ForEach(project => AddProject(project));
        }
    }
}
