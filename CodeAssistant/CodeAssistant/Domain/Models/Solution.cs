using Newtonsoft.Json.Linq;

namespace CodeAssistant.Domain.Models
{
    public class Solution
    {
        private List<Project> _projects;
        public IReadOnlyCollection<Project> Projects { get { return _projects; } }


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
