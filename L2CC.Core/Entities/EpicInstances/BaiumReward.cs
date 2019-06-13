using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.Core.Entities
{
    class BaiumReward : IEpicReward
    {
        private readonly IReadOnlyDictionary<int, IScrollsReward> m_BaiumExpPerLevelTable;
        public BaiumReward(IEpicRewardRepository epicRewardRepository)
        {
            m_BaiumExpPerLevelTable = epicRewardRepository.LoadEpicRewardTable<BaiumReward>();
        }

        public IScrollsReward GetReward(int level)
        {
            if (IsApplicable(level))
            {
                return m_BaiumExpPerLevelTable[level];
            }
            return ExpScrolls.Empty();
        }

        public bool IsApplicable(int currentLevel)
        {
            return m_BaiumExpPerLevelTable.ContainsKey(currentLevel);
        }
    }
}
