using Daf.Xmas.CorruptedMul.Domain.Extractor;
using Daf.Xmas.CorruptedMul.Domain.Infra;
using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Computer;

public class InstructionsComputer(IGetCorruptedData corruptedData, IExtractInstructionsFromCorruptedData extractor) 
    : IComputeInstructionsResult
{
    public int ComputeInstructionsResult()
    {
        throw new NotImplementedException();
    }
}