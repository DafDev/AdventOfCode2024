using Daf.Xmas.Historian.Domain;
using Daf.Xmas.Historian.Domain.Models;
using FluentAssertions;

namespace Daf.Xmas.Historian.Infra.Tests;

public class LocationIdsGetterTests
{
    [Fact]
    public void GetLocationIdsTestShouldReturnLocationDto()
    {
        // Given
        int[] firstHalf = [ 84283, 35360, 17841, 22035 ];
        int[] secondHalf = [ 63343, 98209, 84541, 44413 ];
        var expected = new LocationIdsDto(firstHalf, secondHalf);
        var sut = new LocationIdsGetter();
        // When
        var actual = new LocationIdsGetter().GetLocationIds();
        
        // Should 
        actual.Should().BeEquivalentTo(expected);
    }
}
