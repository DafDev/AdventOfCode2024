using Daf.Xmas.RedNose.Domain.Infrastructure;
using Daf.Xmas.RedNose.Domain.Models;
using System.Linq.Expressions;
using JetBrains.ReSharper.TestRunner.Abstractions.Extensions;

namespace Daf.Xmas.RedNose.Domain.Checker;

public class ReportsChecker(IGetReports reportsGetter) : ICheckReports
{
    public int HowManyReportsAreSafe()
    {
        List<Report> reports = [];
        var reportsDto = reportsGetter.GetAllReports();
        if(reportsDto?.Count() == 0)
            return 0;
        reportsDto.ForEach(dto => reports.Add(Report.FromDto(dto)));
        return reports.Count(report => report.IsSafe());
    }
}