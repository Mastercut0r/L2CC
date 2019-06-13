using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities.EpicInstances;
using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.Core.Entities.EpicInstances
{
    class AntharasReward : IBaiumReward
    {
        private readonly IReadOnlyDictionary<int, IScrollsReward> m_AntharasExpPerLevelTable;
        public AntharasReward(IEpicRewardRepository epicRewardRepository)
        {
            m_AntharasExpPerLevelTable = epicRewardRepository.LoadEpicRewardTable<AntharasReward>();
        }

        public IScrollsReward GetReward(int level)
        {
            if (IsApplicable(level))
            {
                return m_AntharasExpPerLevelTable[level];
            }
            return ExpScrolls.Empty();
        }

        public bool IsApplicable(int currentLevel)
        {
            return m_AntharasExpPerLevelTable.ContainsKey(currentLevel);
        }
    }
}
