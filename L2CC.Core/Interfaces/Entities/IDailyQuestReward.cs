using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.Core.Interfaces.Entities.EpicInstances
{
    interface IDailyQuestReward
    {
        IScrollsReward WeeklyReward(int level, int questAmmountPerWeek = 7);
        IScrollsReward DailyReward(int level);
    }
}
