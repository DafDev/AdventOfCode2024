﻿using Daf.Xmas.Historian.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Xmas.Historian.Infra.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IGetLocationIds, LocationIdsGetter>();
        return services;
    }
}