using CodeAssistant.Application.Interfaces;
using CodeAssistant.Domain.Models;
using CodeAssistant.Infrastructure.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Build.Locator;
using CodeAssistant.Domain.Interfaces;
using Microsoft.Extensions.Logging;

using Solution = CodeAssistant.Domain.Models.Solution;
using Project = CodeAssistant.Domain.Models.Project;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;


namespace CodeAssistant.Infrastructure.ApplicationServices
{
    public class SolutionMSBuilderService : ISolutionBuilderService
    {

        public async Task<Solution> CompileAsync(SolutionReference solutionReference)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Default", LogLevel.Debug)
                       .AddConsole();
            });
            var logger = loggerFactory.CreateLogger<SolutionMSBuilderService>();

            var properties = new Dictionary<string, string>
{
    { "UseLegacySdkResolver", "True" }
};

            using var workspace = MSBuildWorkspace.Create(properties);

            workspace.WorkspaceFailed += (sender, e) =>
            {
                Console.WriteLine($"Workspace failed: {e.Diagnostic.Message}");
            };

            var roslynSolution = await workspace.OpenSolutionAsync(solutionReference.Path);

            Console.WriteLine($"Loaded projects: {roslynSolution.Projects.Count()}, Path: {solutionReference.Path}");
            foreach (var project in roslynSolution.Projects)
            {
                Console.WriteLine($"Project: {project.Name}, Language: {project.Language}");
            }

            Solution builtSolution = new Solution();
            logger.LogInformation("logger works");

            foreach (var project in roslynSolution.Projects)
            {
                var compilation = await project.GetCompilationAsync();

                if (compilation is CSharpCompilation csharpCompilation)
                {
                    Console.WriteLine($"Got CSharpCompilation for project {project.Name}");

                    // Assuming your Project constructor accepts a CSharpCompilation:
                    var newProject = new Project(csharpCompilation);
                    Console.WriteLine(newProject == null ? "null" : newProject.ProjectCompilation.AssemblyName);
                    builtSolution.AddProject(newProject);
                }
                else
                {
                    Console.WriteLine($"Project {project.Name} compilation is not CSharpCompilation.");
                }
            }

            return builtSolution;
        }
    }
}
