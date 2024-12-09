﻿// See https://aka.ms/new-console-template for more information

using Daf.Xmas.Historian.Domain.Calculator;
using Daf.Xmas.Historian.Domain.DependencyInjection;
using Daf.Xmas.Historian.Infra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection()
    .AddInfra()
    .AddDomain()
    .BuildServiceProvider();

var calculator = services.GetRequiredService<ICalculateLocationIdsDistance>();

Console.WriteLine("Result of total distance");
Console.WriteLine(calculator.CalculateTotalDistance());