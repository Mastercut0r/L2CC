using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.DataAccessLayer
{
    class BaiumReward : IEpicRewardRepository
    {
        private readonly IExpScrollsRepository m_Scrolls;
        private readonly IReadOnlyDictionary<int, IScrollsReward> m_BaiumExpPerLevelTable;
        public BaiumReward(IExpScrollsRepository scrolls)
        {
            m_Scrolls = scrolls;
            m_BaiumExpPerLevelTable = new Dictionary<int, IScrollsReward>()
            {
                {70,  m_Scrolls.TwoHundredMil},
                {71,  m_Scrolls.TwoHundredMil},
                {72,  m_Scrolls.TwoHundredMil},
                {73,  m_Scrolls.TwoHundredMil},
                {74,  m_Scrolls.TwoHundredMil},
                {75,  m_Scrolls.TwoHundredMil},
                {76,  m_Scrolls.ThreeHundredMil},
                {77,  m_Scrolls.ThreeHundredMil},
                {78,  m_Scrolls.ThreeHundredMil},
                {79,  m_Scrolls.ThreeHundredMil},
                {80,  m_Scrolls.ThreeHundredMil},
                {81,  m_Scrolls.ThreeHundredMil},
                {82,  m_Scrolls.ThreeHundredMil},
                {83,  m_Scrolls.ThreeHundredMil},
                {84,  m_Scrolls.ThreeHundredMil}
            };
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
