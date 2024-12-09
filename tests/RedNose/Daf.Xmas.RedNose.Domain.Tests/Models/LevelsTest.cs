using FluentAssertions;

namespace Daf.Xmas.RedNose.Domain.Models.Tests;

public class LevelsTest
{
    [Theory, ClassData(typeof(LevelsTestsAllIncreaseOrDecreaseDataByAtLeastOneAtMostThree))]
    public void AllReportsIncreaseOrDecreaseByAtLeastOneATMostThree(Report report, bool expected)
    {
        // When
        bool actual = report.IsSafe();
        
        // Should
        actual.Should().Be(expected);
    }

    [Fact]
    public void FromDtoShouldReturnCorrectLevels()
    {
        // Given
        int[] levels = [7, 6, 4, 2, 1];
        var dto = new ReportDto(levels);
        // When
        var actual = Report.FromDto(dto);
        // Should
        actual.Levels.Should().BeEquivalentTo(levels);
    }
}