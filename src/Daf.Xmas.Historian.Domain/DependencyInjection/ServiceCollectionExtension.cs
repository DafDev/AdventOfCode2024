using Daf.Xmas.Historian.Domain.Calculator;
using Daf.Xmas.Historian.Domain.Similarities;
using Daf.Xmas.Historian.Domain.Sorter;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Xmas.Historian.Domain.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<ISortLocationIds, LocationIdsSorter>();
        services.AddScoped<ICalculateLocationIdsDistance, LocationIdsDistanceCalculator>();
        services.AddScoped<ICalculateSimilarities, SimilaritiesCalculator>();    
        return services;
    }
}