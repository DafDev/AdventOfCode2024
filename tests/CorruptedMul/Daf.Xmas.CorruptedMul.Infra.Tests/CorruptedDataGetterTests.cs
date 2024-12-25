using FluentAssertions;

namespace Daf.Xmas.CorruptedMul.Infra.Tests;

public class CorruptedDataGetterTests
{
    private readonly CorruptedDataGetterFromFIle _sut = new();
    
    [Fact]
    public void GetDataTestsShouldReturnCorrectData()
    {
        // Arrange
        const string expected = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        
        // Act 
        var actual = _sut.GetData();
        
        // Assert
        actual.Should().Be(expected);
    }
}
