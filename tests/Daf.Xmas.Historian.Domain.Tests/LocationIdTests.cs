using Daf.Xmas.Historian.Domain.Models;
using FluentAssertions;

namespace Daf.Xmas.Historian.Domain.Tests;

public class LocationIdTests
{
    [Fact]
    public void GivenDtoWhenFromShouldMapAccordingly()
    {
        // Given
        List<int> firstHalf = [5, 89, 4, 0];
        List<int> secondHalf = [67, 4, 367, 9999];
        var locationIdsDto = new LocationIdsDto(firstHalf, secondHalf);
        var expected = new LocationIds()
        {
            FirstHalf = firstHalf,
            SecondHalf = secondHalf,
        };
        // When
        var actual = LocationIds.FromDto(locationIdsDto);
        
        // Should
        actual.Should().BeEquivalentTo(expected);
    }
}
