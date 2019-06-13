using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.DataAccessLayer.Repository
{
    class BaiumRewardTable : IRewardTable
    {
        private readonly IReadOnlyDictionary<int, IScrollsReward> m_BaiumExpPerLevelTable;
        public BaiumRewardTable(IExpScrollsRepository scrolls = null)
        {
            scrolls = scrolls ?? new ExpScrollsRepository();
            m_BaiumExpPerLevelTable = new Dictionary<int, IScrollsReward>()
            {
                {70,  scrolls.TwoHundredMil},
                {71,  scrolls.TwoHundredMil},
                {72,  scrolls.TwoHundredMil},
                {73,  scrolls.TwoHundredMil},
                {74,  scrolls.TwoHundredMil},
                {75,  scrolls.TwoHundredMil},
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
            return m_BaiumExpPerLevelTable;
        }
    }
}
