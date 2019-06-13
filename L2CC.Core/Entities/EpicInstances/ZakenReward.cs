using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities.EpicInstances;
using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.Core.Entities.EpicInstances
{
    class ZakenReward : IZakenReward
    {
        private readonly IReadOnlyDictionary<int, IScrollsReward> m_ZakenExpPerLevelTable;
        public ZakenReward(IEpicRewardRepository epicRewardRepository)
        {
            m_ZakenExpPerLevelTable = epicRewardRepository.LoadEpicRewardTable<ZakenReward>();
        }

        public IScrollsReward GetReward(int level)
        {
            if (IsApplicable(level))
            {
                return m_ZakenExpPerLevelTable[level];
            }
            return ExpScrolls.Empty();
        }

        public bool IsApplicable(int currentLevel)
        {
            return m_ZakenExpPerLevelTable.ContainsKey(currentLevel);
        }

    }
}
