namespace CodeAssistant.Domain.Models
{
    /// <summary>
    /// Represents the code submitted by user
    /// </summary>
    public class CodeSnippet
    {
        private const int maxCodeLength = 10_000;

        /// <summary>
        /// The code submitted by user
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="CodeSnippet"/>.
        /// </summary>
        /// <param name="code">The code to analyze.</param>
        /// <exception cref="ArgumentNullException">Thrown if code is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if the code exceeds the maximum allowed length.</exception>
        public CodeSnippet(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code));
            if (code.Length > maxCodeLength)
                throw new ArgumentException($"Code is too long, maximum allowed length is {maxCodeLength}.");
            Code = code;
        }
    }
}
