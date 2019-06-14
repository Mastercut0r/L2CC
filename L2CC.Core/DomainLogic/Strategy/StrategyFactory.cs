using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities.EpicInstances;
using System.Collections.Generic;

namespace L2CC.Core.DomainLogic.Strategy
{
    class StrategyFactory : IStrategyFactory
    {
        private readonly IInstanceRewardProvider m_IInstanceRewardProvider;
        private readonly IExperienceRepository m_ExperienceRepository;
        private readonly IDailyQuestReward m_DailyQuestReward;
        public StrategyFactory(
            IInstanceRewardProvider rewardProvider,
            IExperienceRepository experienceRepository,
            IDailyQuestReward dailyQuestReward)
        {
            m_IInstanceRewardProvider = rewardProvider;
            m_ExperienceRepository = experienceRepository;
            m_DailyQuestReward = dailyQuestReward;
        }
        public IReadOnlyCollection<IStrategy> CreateStrategies(
            bool arena,
            bool baium,
            bool antharas,
            bool zaken,
            bool dailyQuests,
            int startBossStage,
            int endBossStage)
        {
            var strategies = new List<IStrategy>();
            if (arena)
            {
                strategies.Add(new Arena(startBossStage, endBossStage, m_IInstanceRewardProvider.LoadClanArena(), m_ExperienceRepository));
            }
            {
                strategies.Add(new Baium(m_IInstanceRewardProvider.LoadRewardRepository<IBaiumReward>(), m_ExperienceRepository));
            }
            if (antharas)
            {
                strategies.Add(new Antharas(m_IInstanceRewardProvider.LoadRewardRepository<IAntharasReward>(), m_ExperienceRepository));
            }
            if (zaken)
            {
                strategies.Add(new Zaken(m_IInstanceRewardProvider.LoadRewardRepository<IZakenReward>(), m_ExperienceRepository));
            }
            if (dailyQuests)
            {
                strategies.Add(new DailyQuests(m_DailyQuestReward, m_ExperienceRepository));
            }
            return strategies;
        }
    }
}
