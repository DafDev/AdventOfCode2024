using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Tests.Computer;

public class InstructionsComputerTestsData : TheoryData<IEnumerable<Instruction>, int>
{
    public InstructionsComputerTestsData()
    {
        Add(null!, 0);
        Add([], 0);
        Add([new(2,4), new(5,5), new(11,8), new(8,5)], 161);
    }
}