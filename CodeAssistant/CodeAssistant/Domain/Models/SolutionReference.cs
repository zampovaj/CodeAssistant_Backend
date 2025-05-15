namespace CodeAssistant.Domain.Models
{
    /// <summary>
    /// Represents path to the solution submitted by user.
    /// </summary>
    public class SolutionReference
    {
        private const int maxPathLength = 200;

        /// <summary>
        /// The code submitted by user
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="SolutionReference"/>.
        /// </summary>
        /// <param name="path">Path to the solution.</param>
        /// <exception cref="ArgumentNullException">Thrown if path is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if the path exceeds the maximum allowed length.</exception>
        public SolutionReference(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            if (path.Length > maxPathLength)
                throw new ArgumentException($"Path is too long, maximum allowed length is {maxPathLength}.");

            Path = path;
        }
    }
}
