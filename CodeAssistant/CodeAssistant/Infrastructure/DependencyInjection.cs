using CodeAssistant.Application.UseCases;
using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Infrastructure.Helpers;
using CodeAssistant.Infrastructure.Services;

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
            services.AddScoped<ISyntaxParser, SyntaxParser>();
            services.AddScoped<ICompilationBuilder, CompilationBuilder>();
            services.AddScoped<IDiagnosticsMapper, DiagnosticsMapper>();
            services.AddScoped<ICodeAnalyzer, RoslynCodeAnalyzer>();
            return services;
        }
    }

}
