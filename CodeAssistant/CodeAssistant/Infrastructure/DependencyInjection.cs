using CodeAssistant.Domain.Interfaces;
using CodeAssistant.Infrastructure.Mock;

namespace CodeAssistant.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICodeAnalyzer, MockCodeAnalyzer>();
            return services;
        }
    }
}
