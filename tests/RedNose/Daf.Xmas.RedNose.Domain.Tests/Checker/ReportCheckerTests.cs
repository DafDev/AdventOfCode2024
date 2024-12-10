using Daf.Xmas.RedNose.Domain.Infrastructure;
using Daf.Xmas.RedNose.Domain.Models;
using FluentAssertions;
using Moq;

namespace Daf.Xmas.RedNose.Domain.Checker.Tests;

public class ReportCheckerTests
{
    private readonly Mock<IGetReports> _reportsGetter = new();
    private readonly ReportsChecker _sut;

    public ReportCheckerTests() => _sut = new ReportsChecker(_reportsGetter.Object);

    [Theory, ClassData(typeof(ReportCheckerTestsData))]
    public void CheckReportsTests(IEnumerable<ReportDto> reports, int expectedCount)
    {
        // Given
        _reportsGetter.Setup(x => x.GetAllReports()).Returns(reports);
        
        // When
        var actual = _sut.HowManyReportsAreSafe();
        
        // Should
        actual.Should().Be(expectedCount);
    }
    
    [Theory, ClassData(typeof(ReportCheckerDampenedTestsData))]
    public void CheckDampenedReportsTests(IEnumerable<ReportDto> reports, int expectedCount)
    {
        // Given
        _reportsGetter.Setup(x => x.GetAllReports()).Returns(reports);
        
        // When
        var actual = _sut.HowManyReportsAreSafe(true);
        
        // Should
        actual.Should().Be(expectedCount);
    }
}