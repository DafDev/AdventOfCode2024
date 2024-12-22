using Daf.Xmas.CorruptedMul.Domain.Computer;
using Daf.Xmas.CorruptedMul.Domain.DependencyInjection;
using Daf.Xmas.CorruptedMul.Infra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddInfra()
    .AddDomain()
    .BuildServiceProvider();
    
var instructionComputer = services.GetRequiredService<IComputeInstructionsResult>();

Console.WriteLine($"Instruction Computer Result:{instructionComputer.ComputeInstructionsResult()}");
