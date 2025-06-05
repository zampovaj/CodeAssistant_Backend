using CodeAssistant.Application.Interfaces;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace CodeAssistant.Infrastructure.ApplicationServices
{
    public class TargetFrameworkDetector : ITargetFrameworkDetector
    {
        public Task<bool> IsWindowsOnlyAsync(string solutionPath)
        {
            var directoryPath = Path.GetDirectoryName(solutionPath);
            var csprojFiles = Directory.GetFiles(directoryPath, "*.csproj", SearchOption.AllDirectories);

            foreach (var project in csprojFiles)
            {
                try
                {
                    var xml = XDocument.Load(project);
                    var root = xml.Root;

                    var tfm = root.Descendants().FirstOrDefault(e =>
                    e.Name.LocalName == "TargetFramework")?.Value;
                    if (!string.IsNullOrEmpty(tfm) && tfm.Contains("windows", StringComparison.OrdinalIgnoreCase))
                            return Task.FromResult(true);

                    var useWpf = root.Descendants().FirstOrDefault(e =>
                    e.Name.LocalName == "UseWpf")?.Value;
                    var useForms = root.Descendants().FirstOrDefault(e =>
                    e.Name.LocalName == "UseWindowsForms")?.Value;

                    if (string.Equals(useWpf, "true", StringComparison.OrdinalIgnoreCase))
                        return Task.FromResult(true);
                    if (string.Equals(useForms, "true", StringComparison.OrdinalIgnoreCase))
                        return Task.FromResult(true);
                }
                catch
                {
                    // ignore malformed xml/project files
                }
            }
            return Task.FromResult(false);
        }
    }
}
