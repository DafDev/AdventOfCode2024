namespace Daf.Xmas.RedNose.Domain.Helper;

public static class LevelsHelper
{
    public static bool CheckLevelsAreEvolvingWithinSteps(IEnumerable<int> levels, int minimumDistance, int maximumDistance ,out int problematicIndex)
    {
        foreach (var level in levels.Index())
        {
            if (level.Index + 1 >= levels.Count())
            {
                problematicIndex = -1; 
                return true;
            }
            
            var nextLevel = levels.ElementAtOrDefault(level.Index + 1);
            var previousLevel = levels.ElementAtOrDefault(level.Index == 0 ? 0 : level.Index - 1);

            if (Math.Abs(level.Item - nextLevel) > maximumDistance ||
                Math.Abs(level.Item - nextLevel) < minimumDistance
                || level.Index > 0 && (Math.Sign(previousLevel - level.Item) != Math.Sign(level.Item - nextLevel)))
            {
                
                var nextNextLevel = levels.ElementAtOrDefault(level.Index + 2);
                problematicIndex = level.Index;
                return false;
            }
        }
                
        problematicIndex = -1; 
        return true;
    }
}