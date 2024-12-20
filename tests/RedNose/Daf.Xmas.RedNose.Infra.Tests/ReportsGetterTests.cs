using Daf.Xmas.RedNose.Domain.Models;
using FluentAssertions;

namespace Daf.Xmas.RedNose.Infra.Tests;

public class ReportsGetterTests
{
    private readonly ReportsGetter _sut = new();
    [Fact]
    public void ReportsGetterShouldReturnAllReports()
    {
        // Given 
        List<ReportDto> expected =
        [
            new([7,6,4,2,1]),
            new([1,2,7,8,9]),
            new([9,7,6,2,1]),
            new([1,3,2,4,5]),
            new([8,6,4,4,1]),
            new([1,3,6,7,9])
        ];
        // When
        var actual = _sut.GetAllReports();
        
        //Should
        actual.Should().BeEquivalentTo(expected);
    }
}