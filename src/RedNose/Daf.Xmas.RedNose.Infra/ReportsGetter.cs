using Daf.Xmas.RedNose.Domain.Infrastructure;
using Daf.Xmas.RedNose.Domain.Models;

namespace Daf.Xmas.RedNose.Infra;

public class ReportsGetter : IGetReports
{
    public string ConnectionString { get; } = "reports.txt";
    public IEnumerable<ReportDto> GetAllReports()
    {
        List<ReportDto> reports = [];
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filepath = Path.Combine(baseDirectory, ConnectionString);
            using StreamReader sr = new (filepath);
            // Read and display lines from the file until the end of
            // the file is reached.
            while (sr.ReadLine() is { } line)
            {
                var values = line.Split(' ');
                reports.Add(new ReportDto(values.Select(int.Parse)));
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine(e.Message);
        }
        return reports;
    }
}