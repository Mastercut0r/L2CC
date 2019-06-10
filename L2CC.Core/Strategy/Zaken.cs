using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities;

namespace L2CC.Core.Strategy
{
    sealed class Zaken : StrategyBase, IStrategy
    {
        IEpicRewardRepository m_EpicBossReward;
        public Zaken(IEpicRewardRepository epicBossRewardRepository, IExperienceRepository experienceRepository) : base(experienceRepository)
        {
            m_EpicBossReward = epicBossRewardRepository;
        }

        public void Apply(ILevelingContainer container)
        {
            if (!LevelUpPossible(container.CurrentLevel)) return;
            if (m_EpicBossReward.IsApplicable(container.CurrentLevel)
                && container.RemainingExperience > m_EpicBossReward.GetReward(container.CurrentLevel).TotalExp)
            {
                var rewards = m_EpicBossReward.GetReward(container.CurrentLevel);
                ApplyScrolls(container, rewards);
            }
        }
    }
}
