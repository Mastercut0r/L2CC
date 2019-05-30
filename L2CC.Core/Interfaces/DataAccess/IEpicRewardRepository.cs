using L2CC.Core.Interfaces.Entities;

namespace L2CC.Core.Interfaces.DataAccess
{
    public interface IEpicRewardRepository
    {
        IScrolls GetReward(int level);
        bool IsApplicable(int currentLevel);

    }
}
