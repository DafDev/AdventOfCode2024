using System.Text.RegularExpressions;

namespace Daf.Xmas.CorruptedMul.Domain.Extractor;

public static partial class InstructionsExtractorRegex
{
    [GeneratedRegex(@"\d{1,3}", RegexOptions.Compiled)]
    public static partial Regex OperandsRegex();
    [GeneratedRegex(@"mul\(\d{1,3},\d{1,3}\)", RegexOptions.Compiled)]
    public static partial Regex InstructionsRegex();
}