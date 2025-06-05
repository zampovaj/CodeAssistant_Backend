using CodeAssistant.Application.Interfaces;
using CodeAssistant.Application.UseCases;
using CodeAssistant.Infrastructure.ApplicationServices;
using Analyzer.Core.Infrastructure;

namespace CodeAssistant.Infrastructure
{
    /// <summary>
    /// Provides extension method to register infrastructure-level dependencies.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds services from the Infrastructure layer to the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<AnalyzeCodeUseCase>();
            services.AddScoped<AnalyzeSolutionUseCase>();
            services.AddScoped<ITargetFrameworkDetector, TargetFrameworkDetector>();
            services.AddScoped<ICodeCompilationBuilderService, CodeCompilationBuilderService>();
            services.AddHttpClient<IWindowsAnalyzerClient, WindowsAnalyzerClient>();
            return services;
        }
    }

}
