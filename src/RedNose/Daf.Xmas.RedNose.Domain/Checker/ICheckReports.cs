using Daf.Xmas.RedNose.Domain.Models;

namespace Daf.Xmas.RedNose.Domain.Checker;

public interface ICheckReports
{
    int HowManyReportsAreSafe(bool isDampened = false);
}