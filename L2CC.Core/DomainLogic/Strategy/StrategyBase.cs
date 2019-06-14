using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities;
using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.Core.DomainLogic.Strategy
{
    abstract class StrategyBase
    {
        private readonly IExperienceRepository m_ExperienceRepository;
        public StrategyBase(IExperienceRepository experienceRepository)
        {
            m_ExperienceRepository = experienceRepository;
        }
        public void ApplyScrolls(ILevelingContainer container, IScrollsReward rewards)
        {
            container.CollectedScrolls.AddScrolls(rewards);
            container.RemainingExperience -= rewards.TotalExp;
            LevelUp(container, rewards.TotalExp);
        }

        public bool LevelUpPossible(int currentLevel)
        {
            return m_ExperienceRepository.IsLevelUpPossible(currentLevel);
        }

        private bool LevelUp(ILevelingContainer container, ulong expIncrease)
        {
            container.ExperienceOnLevel += expIncrease;
            if (container.ExperienceOnLevel >= m_ExperienceRepository.GetExperience(container.CurrentLevel + 1))
            {
                container.CurrentLevel += 1;
                container.ExperienceOnLevel -= m_ExperienceRepository.GetExperience(container.CurrentLevel);
                return true;
            }
            return false;
        }
    }
}
