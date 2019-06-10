using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities;
using L2CC.Core.Interfaces.Entities.EpicInstances;

namespace L2CC.Core.Strategy
{
    sealed class DailyQuests : StrategyBase, IStrategy
    {
        private readonly IDailyQuestReward m_DailyQuest;
        private readonly int m_Days;
        public DailyQuests(IDailyQuestReward dailyQuest, IExperienceRepository experienceRepository, int days = 7) : base(experienceRepository)
        {
            m_DailyQuest = dailyQuest;
            m_Days = days;
        }

        public void Apply(ILevelingContainer container)
        {
            if (!LevelUpPossible(container.CurrentLevel)) return;
            for (int day = 0; day < m_Days; day++)
            {
                var rewards = m_DailyQuest.DailyReward(container.CurrentLevel);
                if (container.RemainingExperience > rewards.TotalExp)
                {
                    ApplyScrolls(container, rewards);
                }
            }
        }
    }
}
