using Microsoft.CodeAnalysis.CSharp;




namespace CodeAssistant.Domain.Models
{
    public class Project
    {
        public CSharpCompilation ProjectCompilation { get; set; }
        public Project(CSharpCompilation projectCompilation)
        {
            ProjectCompilation = projectCompilation;
        }
    }
}
