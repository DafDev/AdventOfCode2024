using Daf.Xmas.RedNose.Domain.Models;

namespace Daf.Xmas.RedNose.Domain.Checker.Tests;

public class ReportCheckerDampenedTestsData : TheoryData<IEnumerable<ReportDto>, int>
{
    public ReportCheckerDampenedTestsData()
    {
        List<ReportDto> reports =
        [
            new([7,6,4,2,1]),
            new([1,2,7,8,9]),
            new([9,7,6,2,1]),
            new([1,3,2,4,5]),
            new([8,6,4,4,1]),
            new([1,3,6,7,9])
        ];
        Add(reports, 4);
    }
}