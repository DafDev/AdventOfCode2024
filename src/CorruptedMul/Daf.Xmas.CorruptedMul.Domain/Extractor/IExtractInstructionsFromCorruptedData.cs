﻿using Daf.Xmas.CorruptedMul.Domain.Models;

namespace Daf.Xmas.CorruptedMul.Domain.Extractor;

public interface IExtractInstructionsFromCorruptedData
{
    IEnumerable<Instruction> ExtractInstructionsFromCorruptedData(string input, bool isToggleEnabled = false);
}