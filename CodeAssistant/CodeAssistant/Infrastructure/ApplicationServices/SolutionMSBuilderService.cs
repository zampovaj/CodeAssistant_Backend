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
    /// <summary>
    /// A service that compiles a solution and its projects into CSharpCompilation instances using MSBuildWorkspace.
    /// </summary>
    public class SolutionMSBuilderService : ISolutionBuilderService
    {
        /// <summary>
        /// Asynchronously compiles a solution by loading it from the given reference, building its projects,
        /// and returning the result as a <see cref="Solution"/> object containing compiled C# projects.
        /// </summary>
        /// <param name="solutionReference">The reference containing the path to the solution file.</param>
        /// <returns>A task representing the asynchronous operation. The task result is a <see cref="Solution"/> object 
        /// containing the compiled projects.</returns>
        /// <exception cref="ArgumentException">Thrown if the solution file path is invalid or not found.</exception>
        /// <exception cref="Exception">Thrown when workspace loading or compilation fails.</exception>
        public async Task<Solution> CompileAsync(SolutionReference solutionReference)
        {

            // Define properties for MSBuildWorkspace
            var properties = new Dictionary<string, string>
            {
                { "UseLegacySdkResolver", "True" }
            };

            // Create MSBuildWorkspace for building the solution
            using var workspace = MSBuildWorkspace.Create(properties);

            // Register an event listener for workspace failures
            workspace.WorkspaceFailed += (sender, e) =>
            {
                Console.WriteLine($"Workspace failed: {e.Diagnostic.Message}");
            };

            // Attempt to load the solution from the specified path
            var roslynSolution = await workspace.OpenSolutionAsync(solutionReference.Path);

            
            foreach (var project in roslynSolution.Projects)
            {
                Console.WriteLine($"Project: {project.Name}, Language: {project.Language}");
            }

            // Prepare a Solution object to hold the compiled projects
            Solution builtSolution = new Solution();

            // Iterate through all projects in the solution and compile them
            foreach (var project in roslynSolution.Projects)
            {
                var compilation = await project.GetCompilationAsync();

                // If the project is a C# project, handle it
                if (compilation is CSharpCompilation csharpCompilation)
                {

                    // Create a Project object for the C# compilation and add it to the solution
                    var newProject = new Project(csharpCompilation);
                    Console.WriteLine(newProject == null ? "null" : newProject.ProjectCompilation.AssemblyName);
                    builtSolution.AddProject(newProject);
                }
                else
                {
                    // Log non-C# projects
                    Console.WriteLine($"Project {project.Name} compilation is not CSharpCompilation.");
                }
            }

            // Return the compiled solution with its projects
            return builtSolution;
        }
    }
}