namespace Daf.Xmas.RedNose.Domain.Models;

public class Report
{
    private const int MaximumDistance = 3;
    private const int MinimumDistance = 1;

    public IEnumerable<int> Levels { get; set; } = [];

    public bool IsSafe()
    {
        if (!(Levels.SequenceEqual(Levels.Order()) || Levels.SequenceEqual(Levels.OrderByDescending(x => x)))) 
            return false;
        foreach (var level in Levels.Index())
        {
            if (level.Index + 1 >= Levels.Count()) return true;
            
            var nextLevel = Levels.ElementAtOrDefault(level.Index + 1);
            if(Math.Abs(level.Item - nextLevel) > MaximumDistance || Math.Abs(level.Item - nextLevel) < MinimumDistance)
                return false;
        }
        
        return true;
    }

    public static Report FromDto(ReportDto reportDto) => new() { Levels = [..reportDto.Levels] };
}