using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Tests.Extractor;

public class InstructionsExtractorTestsData : TheoryData<string,bool,IEnumerable<Instruction>>
{
    public InstructionsExtractorTestsData()
    {
        Add(null!,false,[]);
        Add(string.Empty, false,[]);
        Add("  ", false,[]);
        Add("nothingtoseehere", false,[]);
        Add("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",false,[new(2,4), new(5,5), new(11,8), new(8,5)]);
        Add("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",true,[new(2,4), new(8,5)]);
        Add("xdon't()mul(2,4)&mul[3,7]!^_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",true,[new(8,5)]);
        Add("xdon't()mul(2,4)&mul[3,7]!^_mul(5,5)+mul(32,64](mul(11,8)un()?mul(8,5))",true,[]);
        Add("x()mul(2,4)&mul[3,7]!^_mul(5,5)+mul(32,64](mul(11,8)un()?mul(8,5))",true,[new(2,4), new(5,5), new(11,8), new(8,5)]);
    }
}