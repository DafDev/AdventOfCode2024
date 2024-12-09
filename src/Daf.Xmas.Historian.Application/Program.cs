using Daf.Xmas.Historian.Domain.Calculator;
using Daf.Xmas.Historian.Domain.DependencyInjection;
using Daf.Xmas.Historian.Domain.Similarities;
using Daf.Xmas.Historian.Infra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection()
    .AddInfra()
    .AddDomain()
    .BuildServiceProvider();

var similarities = services.GetRequiredService<ICalculateSimilarities>();

Console.WriteLine("Result of total similarities");
Console.WriteLine(similarities.CalculateSimilarity());