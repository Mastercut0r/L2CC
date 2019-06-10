using System.Collections.Generic;

namespace L2CC.Core.Interfaces.DataAccess
{
    public interface IExperienceRepository
    {
        ulong GetExperience(int level);
        IEnumerable<int> PossibleLevels();
        bool IsLevelUpPossible(int currentLevel);
    }
}
