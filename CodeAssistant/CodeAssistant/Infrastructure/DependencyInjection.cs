using CodeAssistant.Application.UseCases;
using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Infrastructure.Helpers;
using CodeAssistant.Infrastructure.Mock;
using CodeAssistant.Infrastructure.Services;

namespace CodeAssistant.Infrastructure
{
    public static class DependencyInjection
    {
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
