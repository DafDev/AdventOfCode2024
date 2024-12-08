namespace Daf.Xmas.Historian.Domain.Infrastructure;

public interface IGetLocationIds
{
    LocationIdsDto GetLocationIds(string pathFile);
}