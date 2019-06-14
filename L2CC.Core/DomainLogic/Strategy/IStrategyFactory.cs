using System.Collections.Generic;

namespace L2CC.Core.DomainLogic.Strategy
{
    public interface IStrategyFactory
    {
        IReadOnlyCollection<IStrategy> CreateStrategies(
            bool arena,
            bool baium,
            bool antharas,
            bool zaken,
            bool dailyQuests,
            int startBossStage,
            int endBossStage);
    }
}
