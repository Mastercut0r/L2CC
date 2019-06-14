using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities;

namespace L2CC.Core.DomainLogic.Strategy
{
    sealed class Antharas : StrategyBase, IStrategy
    {
        IEpicReward m_EpicBossReward;
        public Antharas(IEpicReward epicBossRewardRepository, IExperienceRepository experienceRepository) : base(experienceRepository)
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
