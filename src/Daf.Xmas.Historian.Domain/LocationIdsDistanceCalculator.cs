using Daf.Xmas.Historian.Domain.Infrastructure;

namespace Daf.Xmas.Historian.Domain;

public class LocationIdsDistanceCalculator(IGetLocationIds locationIdsGetter, ISortLocationIds locationIdsSorter) 
    : ICalculateLocationIdsDistance
{
    public int CalculateDistanceFromLocationIdsFile(string filePath)
    {
        throw new NotImplementedException();
    }
}