using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.Core.Interfaces.Entities
{
    interface IClanArena
    {
        IScrollsReward Reward(int characterLevel, int bossStage);
        IScrollsReward Reward(int characterLevel, int startStage, int endStage);
    }
}
