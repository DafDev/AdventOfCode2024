using Daf.Xmas.Historian.Domain.Calculator;
using Daf.Xmas.Historian.Domain.Infrastructure;
using Daf.Xmas.Historian.Domain.Models;
using Daf.Xmas.Historian.Domain.Similarities;
using Daf.Xmas.Historian.Domain.Sorter;
using FluentAssertions;
using Moq;

namespace Daf.Xmas.Historian.Domain.Tests;

public class SimilaritiesCalculatorTests
{
    private readonly Mock<IGetLocationIds> _locationIdsGetter = new();
    private readonly SimilaritiesCalculator _sut;

    public SimilaritiesCalculatorTests() 
        => _sut = new SimilaritiesCalculator(_locationIdsGetter.Object);
    
    [Fact]
    public void CalculateSimilarities_ShouldReturnExpectedResult()
    {
        // Given
        int[] firstHalf = [3, 4, 2, 1, 3, 3];
        int[] secondHalf = [4, 3, 5, 3, 9, 3];
        var expected = 31;
        var locationIdsDto = new LocationIdsDto(firstHalf, secondHalf);
        _locationIdsGetter.Setup(getter => getter.GetLocationIds())
            .Returns(locationIdsDto);
        
        // When
        var actual =  _sut.CalculateSimilarity();
        
        // Should
        actual.Should().Be(expected);
    }
}