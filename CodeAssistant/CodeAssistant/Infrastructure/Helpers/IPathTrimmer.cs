namespace CodeAssistant.Infrastructure.Helpers
{
    /// <summary>
    /// Used to trim file path from static to dynamic.
    /// </summary>
    public interface IPathTrimmer
    {
        /// <summary>
        /// Removes the starting part of path up until the solution name folder.
        /// </summary>
        /// <param name="fullPath">Path to be trimmed.</param>
        /// <returns>Trimmed path ready for return to the user.</returns>
        public string TrimPath(string fullPath);
    }
}
