using Daf.Xmas.Historian.Domain.Infrastructure;
using Daf.Xmas.Historian.Domain.Models;
using Daf.Xmas.Historian.Domain.Sorter;

namespace Daf.Xmas.Historian.Domain.Calculator;

internal class LocationIdsDistanceCalculator(IGetLocationIds locationIdsGetter, ISortLocationIds locationIdsSorter) 
    : ICalculateLocationIdsDistance
{
    public int CalculateTotalDistance()
    {
        var locationIds = locationIdsSorter
            .SortLocationIds(LocationIds.FromDto(locationIdsGetter.GetLocationIds()));
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