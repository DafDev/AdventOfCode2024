namespace Daf.Xmas.Historian.Domain.Models;

public class LocationIds
{
    public IEnumerable<int> FirstHalf { get; set; } = [];
    public IEnumerable<int> SecondHalf { get; set; } = [];

    public static LocationIds FromDto(LocationIdsDto locationIdsDto)
    {
        return new LocationIds()
        {
            FirstHalf = locationIdsDto.FirstHalf,
            SecondHalf = locationIdsDto.SecondHalf
        };
    }
}