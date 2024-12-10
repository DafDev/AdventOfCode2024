namespace Daf.Xmas.RedNose.Domain.Models;

public class Report
{
    private const int MaximumDistance = 3;
    private const int MinimumDistance = 1;
    private int _problematicIndex = -1;
    public IEnumerable<int> Levels { get; set; } = [];

    public bool IsSafe()
    {
        foreach (var level in Levels.Index())
        {
            if (level.Index + 1 >= Levels.Count()) return true;
            
            var nextLevel = Levels.ElementAtOrDefault(level.Index + 1);
            var previousLevel = Levels.ElementAtOrDefault(level.Index == 0 ? 0 : level.Index - 1);

            if (Math.Abs(level.Item - nextLevel) > MaximumDistance ||
                Math.Abs(level.Item - nextLevel) < MinimumDistance
                || level.Index > 0 && (Math.Sign(previousLevel - level.Item) != Math.Sign(level.Item - nextLevel)))
            {
                _problematicIndex = level.Index;
                return false;
            }
        }
        
        return true;
    }

    public static Report FromDto(ReportDto reportDto) => new() { Levels = [..reportDto.Levels] };

    public bool IsProblemDampened()
    {
        if (IsSafe()) return true;
        var changedLevel = Levels.ToList();
        changedLevel.RemoveAt(_problematicIndex); 
        if (!(changedLevel.SequenceEqual(changedLevel.Order()) || changedLevel.SequenceEqual(changedLevel.OrderByDescending(x => x)))) 
            return false;
        foreach (var level in changedLevel.Index())
        {
            if (level.Index + 1 >= changedLevel.Count) return true;
            
            var nextLevel = changedLevel.ElementAtOrDefault(level.Index + 1);
            if (Math.Abs(level.Item - nextLevel) > MaximumDistance ||
                Math.Abs(level.Item - nextLevel) < MinimumDistance)
            {
                return false;
            }
        }
        return true;
    }
}