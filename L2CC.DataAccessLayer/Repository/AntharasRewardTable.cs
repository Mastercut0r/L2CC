using System.Collections.Generic;
using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.DataAccessLayer.Repository
{
    class AntharasRewardTable : IRewardTable
    {
        private readonly IReadOnlyDictionary<int, IScrollsReward> m_AntharasExpPerLevelTable;
        public AntharasRewardTable(IExpScrollsRepository scrolls = null)
        {
            scrolls = scrolls ?? new ExpScrollsRepository();
            m_AntharasExpPerLevelTable = new Dictionary<int, IScrollsReward>()
            {
                {70,  scrolls.TwoHundredMil},
                {71,  scrolls.TwoHundredMil},
                {72,  scrolls.TwoHundredMil},
                {73,  scrolls.TwoHundredMil},
                {74,  scrolls.TwoHundredMil},
                {75,  scrolls.TwoHundredMil},
                {76,  scrolls.FourHundredMil},
                {77,  scrolls.FourHundredMil},
                {78,  scrolls.FourHundredMil},
                {79,  scrolls.FourHundredMil},
                {80,  scrolls.FourHundredMil},
                {81,  scrolls.FourHundredMil},
                {82,  scrolls.FourHundredMil},
                {83,  scrolls.FourHundredMil},
                {84,  scrolls.FourHundredMil}
            };
        }
        public IReadOnlyDictionary<int, IScrollsReward> LoadRewardTable()
        {
            return m_AntharasExpPerLevelTable;
        }
    }
}
