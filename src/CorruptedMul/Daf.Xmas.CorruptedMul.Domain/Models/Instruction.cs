namespace Daf.Xmas.CorruptedMul.Domain.Models;

public class Instruction(int x, int y)
{
    public int Result => x * y;
}