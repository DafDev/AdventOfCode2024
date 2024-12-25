using Daf.Xmas.CorruptedMul.Domain.Extractor;
using Daf.Xmas.CorruptedMul.Domain.Infra;
using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Computer;

public class InstructionsComputer(IGetCorruptedData corruptedDataGetter, IExtractInstructionsFromCorruptedData instructionsExtractor) 
    : IComputeInstructionsResult
{
    public int ComputeInstructionsResult(bool isToggleEnabled = false)
    {
        var instructions = instructionsExtractor.ExtractInstructionsFromCorruptedData(corruptedDataGetter.GetData(), isToggleEnabled);
        return instructions is null ||!instructions.Any() ? 0 : instructions.Sum(instruction => instruction.Result);
    }
}