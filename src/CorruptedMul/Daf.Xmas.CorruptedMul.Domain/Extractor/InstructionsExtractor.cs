using System.Text.RegularExpressions;
using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Extractor;

public class InstructionsExtractor : IExtractInstructionsFromCorruptedData
{
    private const string Dont = "don't()";
    private const string Do = "do()";
    public IEnumerable<Instruction> ExtractInstructionsFromCorruptedData(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return [];
        
        List<Instruction> instructions = [];
        var matches = InstructionsExtractorRegex.InstructionsRegex().Matches(input);

        foreach (var match in matches)
        {
            var operands = InstructionsExtractorRegex.OperandsRegex().Matches(match.ToString());
            if(operands.Count != 2)
                continue;
            instructions.Add(new Instruction(int.Parse(operands.First().ValueSpan), int.Parse(operands.Last().ValueSpan))); 
        }
        return instructions; 
    }

    public IEnumerable<Instruction> ExtractInstructionsWithToggleEnabledFromCorruptedData(string input)
    {
        var matches = InstructionsExtractorRegex.ToggleRegex().Matches(input);
        foreach (var match in matches)
            input = input.Replace(match.ToString(), string.Empty);
        return ExtractInstructionsFromCorruptedData(input);
    }
}


