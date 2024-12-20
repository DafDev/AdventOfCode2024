namespace Daf.Xmas.RedNose.Domain.Models.Tests;

public class LevelsTestsProblemDampened : TheoryData<Report, bool>
{
    public LevelsTestsProblemDampened()
    {   
        Add(new Report{Levels = [7,6,4,2,1]}, true);
        Add(new Report{Levels = [1,2,7,8,9]}, false);
        Add(new Report{Levels = [9,7,6,2,1]}, false);
        Add(new Report{Levels = [1,3,2,4,5]}, true);
        Add(new Report{Levels = [8,6,4,4,1]}, true);
        Add(new Report{Levels = [1,3,6,7,9]}, true);
        Add(new Report{Levels = [5,3,6,7,9]}, true);
        Add(new Report{Levels = [5,9,6,4,2]}, true);
        Add(new Report{Levels = [7,9,8,7,5]}, true);
        Add(new Report{Levels = [11,10,8,7,9]}, true);

    }
    
}