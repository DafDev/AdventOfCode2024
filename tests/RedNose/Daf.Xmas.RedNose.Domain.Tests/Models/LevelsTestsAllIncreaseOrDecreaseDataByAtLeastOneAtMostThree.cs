namespace Daf.Xmas.RedNose.Domain.Models.Tests;

public class LevelsTestsAllIncreaseOrDecreaseDataByAtLeastOneAtMostThree : TheoryData<Report, bool>
{
    public LevelsTestsAllIncreaseOrDecreaseDataByAtLeastOneAtMostThree()
    {   
        Add(new Report{Levels = [7,6,4,2,1]}, true);
        Add(new Report{Levels = [1,2,7,8,9]}, false);
        Add(new Report{Levels = [9,7,6,2,1]}, false);
        Add(new Report{Levels = [1,3,2,4,5]}, false);
        Add(new Report{Levels = [8,6,4,4,1]}, false);
        Add(new Report{Levels = [1,3,6,7,9]}, true);

    }
    
}