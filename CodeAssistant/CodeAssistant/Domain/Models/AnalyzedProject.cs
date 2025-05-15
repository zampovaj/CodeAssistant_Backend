namespace CodeAssistant.Domain.Models
{
    public class AnalyzedProject
    {
        public string Name { get; set; }
        public IReadOnlyCollection<CodeError> Errors { get; set; }
        public AnalyzedProject(string name, IReadOnlyCollection<CodeError> errors)
        {
            Name = name;
            Errors = errors;
        }
    }
}
