using FluentAssertions;

namespace Daf.Xmas.Historian.Domain.Tests;

public class LocationIdsSorterTests
{
    [Fact]
    public void GivenUnsortedLocationIdWhenSortLocationIdsShouldReturnSortedLocationIds()
    {
        // Given
        List<int> firstHalf = [5, 89, 4, 0];
        List<int> secondHalf = [67, 4, 367, 99];
        var input = new LocationIds()
        {
            FirstHalf = firstHalf,
            SecondHalf = secondHalf,
        };
        var expected = new LocationIds()
        {
            FirstHalf = [0, 4, 5, 89],
            SecondHalf = [4, 67, 99, 367],
        };
        var sut = new LocationIdsSorter();
        // When
        var actual = sut.SortLocationIds(input);
        
        // Should
        actual.Should().BeEquivalentTo(expected);
    }
}