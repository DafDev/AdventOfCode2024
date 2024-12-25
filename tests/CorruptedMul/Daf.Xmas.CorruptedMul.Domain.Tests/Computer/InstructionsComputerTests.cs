using Daf.Xmas.CorruptedMul.Domain.Computer;
using Daf.Xmas.CorruptedMul.Domain.Extractor;
using Daf.Xmas.CorruptedMul.Domain.Infra;
using Daf.Xmas.CorruptedMul.Domain.Models;
using FluentAssertions;
using Moq;

namespace Daf.Xmas.CorruptedMul.Domain.Tests.Computer;

public class InstructionsComputerTests
{
    private readonly Mock<IExtractInstructionsFromCorruptedData> _dataExtractor = new();
    private readonly Mock<IGetCorruptedData> _dataGetter = new();

    private readonly InstructionsComputer _sut;

    public InstructionsComputerTests() => _sut = new(_dataGetter.Object, _dataExtractor.Object);

    [Theory, ClassData(typeof(InstructionsComputerTestsData))]
    public void GivenCorruptedDataReturnExpectedResult(IEnumerable<Instruction> instructions, int expectedResult)
    {
        // Given
        _dataExtractor.Setup(extractor 
            => extractor.ExtractInstructionsFromCorruptedData(It.IsAny<string>(),false))
            .Returns(instructions);
        
        // When
        var actual = _sut.ComputeInstructionsResult();
        
        // Should
        actual.Should().Be(expectedResult);   
    }
}