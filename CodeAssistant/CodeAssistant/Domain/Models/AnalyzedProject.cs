namespace CodeAssistant.Domain.Models
{
    /// <summary>
    /// Represents the analyzed project.
    /// </summary>
    public class AnalyzedProject
    {
        /// <summary>
        /// Assembly name of the analyzed project.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  Readonly colection of compile errors of this project.
        /// </summary>
        public IReadOnlyCollection<CodeError> Errors { get; set; }
        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzedProject"/>
        /// </summary>
        /// <param name="name">Name of the analyzed project.</param>
        /// <param name="errors">Compile errors of the analyzed project.</param>
        /// <exception cref="ArgumentNullException">Thrown if one of parameters is null or empty.</exception>
        public AnalyzedProject(string name, IReadOnlyCollection<CodeError> errors)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
            if (errors == null) throw new ArgumentNullException(nameof(errors));
            Errors = errors;
        }
    }
}
