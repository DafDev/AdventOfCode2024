using Daf.Xmas.Historian.Domain.Infrastructure;

namespace Daf.Xmas.Historian.Domain;

public class LocationIdsDistanceCalculator(IGetLocationIds locationIdsGetter, ISortLocationIds locationIdsSorter) 
    : ICalculateLocationIdsDistance
{
    public int CalculateDistanceFromLocationIdsFile(string filePath)
    {
        var locationIds = locationIdsSorter
            .SortLocationIds(LocationIds.FromDto(locationIdsGetter.GetLocationIds(filePath)));
        if (locationIds.FirstHalf.Count() != locationIds.SecondHalf.Count())
            throw new ArgumentException("LocationIds are not the same size.");
        var totalDistance = 0;
        var firstHalf=locationIds.FirstHalf.ToArray();
        var secondHalf=locationIds.SecondHalf.ToArray();
        for (int i = 0; i < locationIds.FirstHalf.Count(); i++)
        {
            totalDistance += Math.Abs(firstHalf[i] - secondHalf[i]);
        }
        return totalDistance;
    }
}