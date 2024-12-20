using System.Diagnostics.CodeAnalysis;
using Daf.Xmas.RedNose.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Xmas.RedNose.Infra.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IGetReports, ReportsGetter>();
        return services;
    }
}