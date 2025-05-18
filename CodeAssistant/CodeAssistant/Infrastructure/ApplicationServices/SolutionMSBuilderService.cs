using CodeAssistant.Application.Interfaces;
using CodeAssistant.Domain.Models;
using CodeAssistant.Infrastructure.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Build.Locator;
using CodeAssistant.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using CodeAssistant.Debugging;

using Solution = CodeAssistant.Domain.Models.Solution;
using Project = CodeAssistant.Domain.Models.Project;
using System.Text;


namespace CodeAssistant.Infrastructure.ApplicationServices
{
    public class SolutionMSBuilderService : ISolutionBuilderService
    {

        public async Task<Solution> CompileAsync(SolutionReference solutionReference)
        {
            var logger = LoggingFactory.CreateLogger<SolutionMSBuilderService>();
            using var workspace = MSBuildWorkspace.Create();

            var roslynSolution = await workspace.OpenSolutionAsync(solutionReference.Path);
            Solution builtSolution = new Solution();

            logger.LogInformation(builtSolution.ToString());

            foreach (var project in roslynSolution.Projects)
            {
                var compilation = await project.GetCompilationAsync();
                if (compilation != null)
                {
                    builtSolution.AddProject(new Project(compilation));
                }
            }
            return builtSolution;
        }
    }
}
