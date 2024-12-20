namespace Daf.Xmas.CorruptedMul.Domain.Infra;

public interface IGetCorruptedData
{
    string ConnectionString { get; }
    string GetData();
}