namespace L2CC.Core.Interfaces.DataAccess
{
    interface IClanArena
    {
        IScrollReward Reward(int characterLevel, int bossStage);
        IScrollReward Reward(int characterLevel, int startStage, int endStage);
    }
}
