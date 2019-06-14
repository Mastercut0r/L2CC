using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities;

namespace L2CC.Core.DomainLogic.Strategy
{
    sealed class Arena : StrategyBase, IStrategy
    {
        private readonly IClanArena m_ClanArena;
        private readonly int m_StartBossStage;
        private readonly int m_EndBossStage;

        public Arena(int startBossStage, int endBossStage, IClanArena clanArena, IExperienceRepository experienceRepository)
            : base(experienceRepository)
        {
            m_ClanArena = clanArena;
            m_StartBossStage = startBossStage;
            m_EndBossStage = endBossStage;
        }

        public void Apply(ILevelingContainer container)
        {
            if (!LevelUpPossible(container.CurrentLevel)) return;
            var rewards = m_ClanArena.Reward(container.CurrentLevel, m_StartBossStage, m_EndBossStage);
            if (container.RemainingExperience > rewards.TotalExp)
            {
                //ArenaRbKillCount += endBossStage - startBossStage;
                ApplyScrolls(container, rewards);
            }
        }
    }
}
