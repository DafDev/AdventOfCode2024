using Daf.Xmas.CorruptedMul.Domain.Extractor;
using Daf.Xmas.CorruptedMul.Domain.Models;
using FluentAssertions;

namespace Daf.Xmas.CorruptedMul.Domain.Tests.Extractor;

public class InstructionsExtractorTests
{
    private readonly InstructionsExtractor _sut = new();

    [Theory, ClassData(typeof(InstructionsExtractorTestsData))]
    public void ExtractInstructionsTest(string input,  bool isToggleEnabled, IEnumerable<Instruction> expected)
    {
        //Act
        var actual = _sut.ExtractInstructionsFromCorruptedData(input, isToggleEnabled);

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }
}