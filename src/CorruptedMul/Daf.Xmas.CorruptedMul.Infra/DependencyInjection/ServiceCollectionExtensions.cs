using System.Diagnostics.CodeAnalysis;
using Daf.Xmas.CorruptedMul.Domain.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Xmas.CorruptedMul.Infra.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IGetCorruptedData, CorruptedDataGetterFromFIle>();
        return services;
    }
}