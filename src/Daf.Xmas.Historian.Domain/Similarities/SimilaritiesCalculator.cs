using Daf.Xmas.Historian.Domain.Infrastructure;
using Daf.Xmas.Historian.Domain.Models;

namespace Daf.Xmas.Historian.Domain.Similarities;

public class SimilaritiesCalculator(IGetLocationIds locationIdsGetter) : ICalculateSimilarities
{
    public int CalculateSimilarity()
    {
        var locationIds = LocationIds.FromDto(locationIdsGetter.GetLocationIds());
        var totalSimilarity = 0;
        foreach (var number in locationIds.FirstHalf)
        {
            var similarityForThisNumber = locationIds.SecondHalf
                .Select(x => x == number)
                .Count(x => x);
            totalSimilarity += number * similarityForThisNumber;
        }
        
        return totalSimilarity;
    }
}