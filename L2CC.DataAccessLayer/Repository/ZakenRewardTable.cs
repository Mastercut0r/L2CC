using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.DataAccessLayer.Repository
{
    class ZakenRewardTable : IRewardTable
    {
        private readonly IReadOnlyDictionary<int, IScrollsReward> m_ZakenExpPerLevelTable;
        public ZakenRewardTable(IExpScrollsRepository scrolls = null)
        {
            scrolls = scrolls ?? new ExpScrollsRepository();
            m_ZakenExpPerLevelTable = new Dictionary<int, IScrollsReward>()
            {
                {70,  scrolls.HundredMil},
                {71,  scrolls.HundredMil},
                {72,  scrolls.HundredMil},
                {73,  scrolls.HundredMil},
                {74,  scrolls.HundredMil},
                {75,  scrolls.HundredMil},
                {76,  scrolls.ThreeHundredMil},
                {77,  scrolls.ThreeHundredMil},
                {78,  scrolls.ThreeHundredMil},
                {79,  scrolls.ThreeHundredMil},
                {80,  scrolls.ThreeHundredMil},
                {81,  scrolls.ThreeHundredMil},
                {82,  scrolls.ThreeHundredMil},
                {83,  scrolls.ThreeHundredMil},
                {84,  scrolls.ThreeHundredMil}
            };
        }
        public IReadOnlyDictionary<int, IScrollsReward> LoadRewardTable()
        {
            return m_ZakenExpPerLevelTable;
        }

    }
}
