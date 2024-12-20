using Daf.Xmas.RedNose.Domain.Models;

namespace Daf.Xmas.RedNose.Domain.Infrastructure;

public interface IGetReports
{
    string ConnectionString { get; }
    IEnumerable<ReportDto> GetAllReports();
}