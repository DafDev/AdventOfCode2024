using System.Diagnostics.CodeAnalysis;
using Daf.Xmas.RedNose.Domain.Checker;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Xmas.RedNose.Domain.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ICheckReports, ReportsChecker>();
        return services;
    }
}