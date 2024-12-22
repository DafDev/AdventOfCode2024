using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Tests.Extractor;

public class InstructionsExtractorTestsData : TheoryData<string, IEnumerable<Instruction>>
{
    public InstructionsExtractorTestsData()
    {
        Add("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",[new(2,4), new(8,5)]);
        Add("xdon't()mul(2,4)&mul[3,7]!^_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",[new(8,5)]);
        Add("xdon't()mul(2,4)&mul[3,7]!^_mul(5,5)+mul(32,64](mul(11,8)un()?mul(8,5))",[]);
        Add("x()mul(2,4)&mul[3,7]!^_mul(5,5)+mul(32,64](mul(11,8)un()?mul(8,5))",[new(2,4), new(5,5), new(11,8), new(8,5)]);
    }
}