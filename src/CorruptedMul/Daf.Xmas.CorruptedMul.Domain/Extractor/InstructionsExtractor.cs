using System.Text.RegularExpressions;
using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Extractor;

public class InstructionsExtractor : IExtractInstructionsFromCorruptedData
{
    private const string Dont = "don't()";
    private const string Do = "do()";
    public IEnumerable<Instruction> ExtractInstructionsFromCorruptedData(string input, bool isToggleEnabled = false)
    {
        if (string.IsNullOrWhiteSpace(input))
            return [];

        if (isToggleEnabled)
        {
            var toggleMatches = InstructionsExtractorRegex.ToggleRegex().Matches(input);
            if (toggleMatches.Count > 0)
            {
                foreach (var match in toggleMatches)
                    input = input.Replace(match.ToString(), string.Empty);
            }
        }
        List<Instruction> instructions = [];
        var matches = InstructionsExtractorRegex.InstructionsRegex().Matches(input);
        if (matches.Count == 0)
            return instructions;
        foreach (var match in matches)
        {
            var operands = InstructionsExtractorRegex.OperandsRegex().Matches(match.ToString());
            if(operands.Count != 2)
                continue;
            instructions.Add(new Instruction(int.Parse(operands.First().ValueSpan), int.Parse(operands.Last().ValueSpan))); 
        }
        return instructions; 
    }
}


