using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.Core.Interfaces.DataAccess
{
    public interface IEpicReward
    {
        IScrollsReward GetReward(int level);
        bool IsApplicable(int currentLevel);
    }
}
