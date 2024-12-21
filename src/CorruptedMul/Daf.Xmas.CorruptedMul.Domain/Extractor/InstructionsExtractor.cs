using System.Text.RegularExpressions;
using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Extractor;

public class InstructionsExtractor : IExtractInstructionsFromCorruptedData
{
    public IEnumerable<Instruction> ExtractInstructionsFromCorruptedData(string input)
    {
        var matches = InstructionsExtractorRegex.InstructionsRegex().Matches(input);

        foreach (var match in matches)
        {
            var operands = InstructionsExtractorRegex.OperandsRegex().Matches(match.ToString());
            if(operands.Count != 2)
                continue;
            yield return new Instruction(int.Parse(operands.First().ValueSpan), int.Parse(operands.Last().ValueSpan));
        }
    }


}


