using Daf.Xmas.Historian.Domain.Models;

namespace Daf.Xmas.Historian.Domain.Sorter;

internal class LocationIdsSorter : ISortLocationIds
{
    public LocationIds SortLocationIds(LocationIds locationIds)
    {
        var sortedLocations = new LocationIds()
        {
            FirstHalf = [..locationIds.FirstHalf.Order()],
            SecondHalf = [..locationIds.SecondHalf.Order()],
        };
        return sortedLocations;
    }
}