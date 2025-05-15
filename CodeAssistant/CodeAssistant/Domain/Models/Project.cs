using Microsoft.CodeAnalysis;

namespace CodeAssistant.Domain.Models
{
    public class Project
    {
        public Compilation ProjectCompilation { get; set; }
        public Project(Compilation projectCompilation)
        {
            ProjectCompilation = projectCompilation;
        }
    }
}
