using Daf.Xmas.RedNose.Domain.Infrastructure;
using Daf.Xmas.RedNose.Domain.Models;

namespace Daf.Xmas.RedNose.Domain.Checker;

public class ReportsChecker(IGetReports reportsGetter) : ICheckReports
{
    public int HowManyReportsAreSafe()
    {
        List<Report> reports = [];
        var reportsDto = reportsGetter.GetAllReports();
        if(reportsDto?.Count() == 0)
            return 0;
        reportsDto.ToList().ForEach(dto => reports.Add(Report.FromDto(dto)));
        return reports.Count(report => report.IsSafe());
    }
}