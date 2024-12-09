using Daf.Xmas.RedNose.Domain.Checker;
using Daf.Xmas.RedNose.Domain.DependencyInjection;
using Daf.Xmas.RedNose.Infra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddInfra()
    .AddDomain()
    .BuildServiceProvider();
    
var safetyReport = services.GetRequiredService<ICheckReports>();

Console.WriteLine("Number of safe reports");
Console.WriteLine(safetyReport.HowManyReportsAreSafe());