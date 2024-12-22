using Daf.Xmas.CorruptedMul.Domain.Extractor;
using Daf.Xmas.CorruptedMul.Domain.Models;
using FluentAssertions;

namespace Daf.Xmas.CorruptedMul.Domain.Tests.Extractor;

public class InstructionsExtractorTests
{
    private readonly InstructionsExtractor _sut = new();

    [Fact]
    public void ExtractInstructionsTest()
    {
        // Arrange
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        List<Instruction> expected = [new(2,4), new(5,5), new(11,8), new(8,5)];
        
        //Act
        var actual = _sut.ExtractInstructionsFromCorruptedData(input);

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory, ClassData(typeof(InstructionsExtractorTestsData))]
    public void GetDataTestsWithTogglerEnabledShouldReturnCorrectData(string input, IEnumerable<Instruction> expected)
    {
        //Act
        var actual = _sut.ExtractInstructionsWithToggleEnabledFromCorruptedData(input);

        //Assert
        actual.Should().BeEquivalentTo(expected);
        
    }
}