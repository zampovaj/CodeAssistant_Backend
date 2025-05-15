namespace CodeAssistant.Domain.Models
{
    public class AnalyzedSolution
    {

        private List<AnalyzedProject> _projects;
        public IReadOnlyCollection<AnalyzedProject> Projects { get { return _projects; } }

        public void AddProject(AnalyzedProject project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            _projects.Add(project);
        }
        public void AddProjects(IReadOnlyCollection<AnalyzedProject> projects)
        {
            if (projects == null)
                throw new ArgumentNullException(nameof(projects));
            projects.ToList().ForEach(project => AddProject(project));
        }
    }
}
