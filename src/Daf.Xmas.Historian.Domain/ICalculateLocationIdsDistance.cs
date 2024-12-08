using System.Drawing;

namespace Daf.Xmas.Historian.Domain;

public interface ICalculateLocationIdsDistance
{
    int CalculateDistanceFromLocationIdsFile(string filePath);
}