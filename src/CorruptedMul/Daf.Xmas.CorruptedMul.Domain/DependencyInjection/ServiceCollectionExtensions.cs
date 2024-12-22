using System.Diagnostics.CodeAnalysis;
using Daf.Xmas.CorruptedMul.Domain.Computer;
using Daf.Xmas.CorruptedMul.Domain.Extractor;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Xmas.CorruptedMul.Domain.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IExtractInstructionsFromCorruptedData, InstructionsExtractor>();
        services.AddScoped<IComputeInstructionsResult, InstructionsComputer>();
        return services;
    }
}