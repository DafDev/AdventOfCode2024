using System.Text;
using Daf.Xmas.CorruptedMul.Domain.Infra;

namespace Daf.Xmas.CorruptedMul.Infra;

public class CorruptedDataGetterFromFIle : IGetCorruptedData
{
    public string ConnectionString { get; } = "corruptedData.txt";
    private const string LineSeparator = """\r\n""";
    public string GetData()
    {
        var stringBuilder = new StringBuilder();
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
                stringBuilder.Append(line.Replace(LineSeparator,"").Trim());
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine(e.Message);
        }
        return stringBuilder.ToString();
    }
}
