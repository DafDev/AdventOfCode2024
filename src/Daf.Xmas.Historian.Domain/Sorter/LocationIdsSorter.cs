using Daf.Xmas.Historian.Domain.Models;

namespace Daf.Xmas.Historian.Domain.Sorter;

internal class LocationIdsSorter : ISortLocationIds
{
    public LocationIds SortLocationIds(LocationIds locationIds)
    {
        var sortedLocations = new LocationIds()
        {
            FirstHalf = [..locationIds.FirstHalf.ToList()],
            SecondHalf = [..locationIds.SecondHalf.ToList()],
        };
        sortedLocations.FirstHalf.ToList().Sort();
        sortedLocations.SecondHalf.ToList().Sort();
        return sortedLocations;
    }
}