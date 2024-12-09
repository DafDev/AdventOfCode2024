using System.Collections.Immutable;
using Daf.Xmas.Historian.Domain;
using Daf.Xmas.Historian.Domain.Infrastructure;
using Daf.Xmas.Historian.Domain.Models;

namespace Daf.Xmas.Historian.Infra;

internal class LocationIdsGetter : IGetLocationIds
{
    public string ConnectionString { get; } = "data.csv";

    public LocationIdsDto GetLocationIds()
    {
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using StreamReader sr = new (ConnectionString);
            List<string> firstHalfList = [];
            List<string> secondHalfList = [];
            // Read and display lines from the file until the end of
            // the file is reached.
            while (sr.ReadLine() is { } line)
            {
                var values = line.Split(',');
                if (values.Length != 2)
                    throw new FormatException("Invalid file format");
                firstHalfList.Add(values[0]);
                secondHalfList.Add(values[1]);
            }
            int[] firstHalfIds = firstHalfList.Select(int.Parse).ToArray();
            int[] secondHalfIds = secondHalfList.Select(int.Parse).ToArray();
            return new LocationIdsDto(firstHalfIds, secondHalfIds);
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine(e.Message);
        }

        return new LocationIdsDto(ImmutableArray<int>.Empty, ImmutableArray<int>.Empty);
    }
}
