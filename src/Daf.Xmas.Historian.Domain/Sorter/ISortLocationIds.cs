using Daf.Xmas.Historian.Domain.Models;

namespace Daf.Xmas.Historian.Domain.Sorter;

public interface ISortLocationIds
{
    LocationIds SortLocationIds(LocationIds locationIds);
}