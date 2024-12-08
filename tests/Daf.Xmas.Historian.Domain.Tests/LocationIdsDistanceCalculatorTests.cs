using Daf.Xmas.Historian.Domain.Infrastructure;
using FluentAssertions;
using Moq;

namespace Daf.Xmas.Historian.Domain.Tests;

public class LocationIdsDistanceCalculatorTests
{
    private readonly Mock<ISortLocationIds> _locationIdsSorter = new();
    private readonly Mock<IGetLocationIds> _locationIdsGetter = new();
    private readonly LocationIdsDistanceCalculator _sut;

    public LocationIdsDistanceCalculatorTests() 
        => _sut = new LocationIdsDistanceCalculator(_locationIdsGetter.Object,_locationIdsSorter.Object);

    [Fact]
    public void CalculateDistance_should_return_expected_result()
    {
        // Given
        List<int> firstHalf = [5, 89, 4, 0];
        List<int> secondHalf = [67, 4, 367, 99];
        var locationIdsDto = new LocationIdsDto(firstHalf, secondHalf);
        _locationIdsGetter.Setup(getter => getter.GetLocationIds(It.IsAny<string>()))
            .Returns(locationIdsDto);
        var locationIds = LocationIds.FromDto(locationIdsDto);
        var locationIdsSorted = new LocationIds()
        {
            FirstHalf = [0, 4, 5, 89],
            SecondHalf = [4, 67, 99, 367],
        };
        _locationIdsSorter.Setup(sorter => sorter.SortLocationIds(locationIds)).Returns(locationIdsSorted);
        var expected = 45;
        // When
        var actual = _sut.CalculateDistanceFromLocationIdsFile("fileName");
        // Should
        actual.Should().Be(expected);

    }
}