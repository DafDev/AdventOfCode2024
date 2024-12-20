using System.Text.RegularExpressions;
using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Extractor;

public partial class InstructionsExtractor : IExtractInstructionsFromCorruptedData
{
    private readonly Regex _instructionRegex = InstructionsRegex();
    private readonly Regex _operands = OperandsRegex();
    public IEnumerable<Instruction> ExtractInstructionsFromCorruptedData(string input)
    {
        var matches = _instructionRegex.Matches(input);

        foreach (var match in matches)
        {
            var operands = _operands.Matches(match.ToString());
            if(operands.Count != 2)
                continue;
            yield return new Instruction(int.Parse(operands.First().ValueSpan), int.Parse(operands.Last().ValueSpan));
        }
    }

    [GeneratedRegex(@"\d{1,3}", RegexOptions.Compiled)]
    private static partial Regex OperandsRegex();
    [GeneratedRegex(@"mul\(\d{1,3},\d{1,3}\)", RegexOptions.Compiled)]
    private static partial Regex InstructionsRegex();
}