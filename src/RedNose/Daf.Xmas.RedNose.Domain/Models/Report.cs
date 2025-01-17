﻿using Daf.Xmas.RedNose.Domain.Helper;

namespace Daf.Xmas.RedNose.Domain.Models;

public class Report
{
    private const int MaximumDistance = 3;
    private const int MinimumDistance = 1;
    private int _problematicIndex = -1;
    public IEnumerable<int> Levels { get; set; } = [];

    public bool IsSafe()
        => LevelsHelper.CheckLevelsAreEvolvingWithinSteps(Levels, MinimumDistance, MaximumDistance ,out _problematicIndex);

    public static Report FromDto(ReportDto reportDto) => new() { Levels = [..reportDto.Levels] };

    public bool IsProblemDampened()
    {
        if (IsSafe()) return true;
        var changedLevel = Levels.ToList();
        changedLevel.RemoveAt(_problematicIndex);
        var levelsAreFinallyOkay = LevelsHelper.CheckLevelsAreEvolvingWithinSteps(changedLevel, MinimumDistance, MaximumDistance,
            out _);
        if (levelsAreFinallyOkay)
            return levelsAreFinallyOkay;

        if (_problematicIndex > 0 &&
            LevelsHelper
                .CheckLevelsAreEvolvingWithinSteps(
                    Levels.Index().Where(pair => pair.Index != _problematicIndex - 1).Select(pair => pair.Item),
                    MinimumDistance,
                    MaximumDistance,
                    out _))
            return true;
        
        return LevelsHelper
            .CheckLevelsAreEvolvingWithinSteps(Levels.Index().Where(pair => pair.Index != _problematicIndex + 1).Select(pair => pair.Item), 
                MinimumDistance,
                MaximumDistance,
                out _);
    }
}