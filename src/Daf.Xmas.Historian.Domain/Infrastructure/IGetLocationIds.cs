using Daf.Xmas.Historian.Domain.Models;

namespace Daf.Xmas.Historian.Domain.Infrastructure;

public interface IGetLocationIds
{
    string ConnectionString { get; }
    LocationIdsDto GetLocationIds();
}