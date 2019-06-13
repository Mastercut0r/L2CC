using L2CC.Core.Interfaces.Entities.Scrolls;
using System;
using System.Collections.Generic;

namespace L2CC.DataAccessLayer.Repository
{
    class ClanArenaRewardTable : IClanArenaRewardTable
    {
        private IReadOnlyDictionary<int, IScrollsReward> m_FourtyLevels;
        private IReadOnlyDictionary<int, IScrollsReward> m_FiftyLevels;
        private IReadOnlyDictionary<int, IScrollsReward> m_SixtyLevels;
        private IReadOnlyDictionary<int, IScrollsReward> m_SeventyLevels;
        private IReadOnlyDictionary<int, IScrollsReward> m_SeventySevenLevels;
        private IReadOnlyDictionary<int, IScrollsReward> m_SeventyEightLevels;
        private readonly IExpScrollsRepository m_Scrolls;
        public ClanArenaRewardTable(IExpScrollsRepository scrolls)
        {
            m_Scrolls = scrolls;
        }
        public IReadOnlyDictionary<int, IScrollsReward> LoadRewardTableForLevel(int level)
        {
            if (level >= 40 && level <= 49)
            {
                return m_FourtyLevels ?? InitFourty();
            }
            else if (level <= 59)
            {
                return m_FiftyLevels ?? InitFifty();
            }
            else if (level <= 69)
            {
                return m_SixtyLevels ?? InitSixty();
            }
            else if (level <= 76)
            {
                return m_SeventyLevels ?? InitSeventy();
            }
            else if (level == 77)
            {
                return m_SeventySevenLevels ?? InitSeventySeven();
            }
            else if (level <= 85)
            {
                return m_SeventyEightLevels ?? InitSeventyEightSeven();
            }
            else
            {
                throw new NotSupportedException(nameof(level));
            }
        }
        private IReadOnlyDictionary<int, IScrollsReward> InitFourty()
        {
            var fourty = new Dictionary<int, IScrollsReward>();
            for (int level = 1; level < 26; level++)
            {
                fourty.Add(level, m_Scrolls.TenMil);
            }
            m_FourtyLevels = new Dictionary<int, IScrollsReward>(fourty);
            return m_FourtyLevels;
        }

        private IReadOnlyDictionary<int, IScrollsReward> InitFifty()
        {
            var fifty = new Dictionary<int, IScrollsReward>();
            for (int level = 1; level < 26; level++)
            {
                fifty.Add(level, m_Scrolls.ThirtyMil);
            }
            m_FiftyLevels = new Dictionary<int, IScrollsReward>(fifty);
            return m_FiftyLevels;
        }

        private IReadOnlyDictionary<int, IScrollsReward> InitSixty()
        {
            return m_SixtyLevels = new Dictionary<int, IScrollsReward>()
                {
                    {1, m_Scrolls.FiftyMil},
                    {2, m_Scrolls.FiftyMil},
                    {3, m_Scrolls.FiftyMil},
                    {4, m_Scrolls.FiftyMil},
                    {5, m_Scrolls.FiftyMil},
                    {6, m_Scrolls.EightyMil},
                    {7, m_Scrolls.EightyMil},
                    {8, m_Scrolls.EightyMil},
                    {9, m_Scrolls.EightyMil},
                    {10, m_Scrolls.EightyMil},
                    {11, m_Scrolls.EightyMil},
                    {12, m_Scrolls.EightyMil},
                    {13, m_Scrolls.EightyMil},
                    {14, m_Scrolls.EightyMil},
                    {15, m_Scrolls.EightyMil},
                    {16, m_Scrolls.EightyMil},
                    {17, m_Scrolls.EightyMil},
                    {18, m_Scrolls.EightyMil},
                    {19, m_Scrolls.EightyMil},
                    {20, m_Scrolls.EightyMil},
                    {21, m_Scrolls.EightyMil},
                    {22, m_Scrolls.EightyMil},
                    {23, m_Scrolls.EightyMil},
                    {24, m_Scrolls.EightyMil},
                    {25, m_Scrolls.EightyMil}
                };
        }
        private IReadOnlyDictionary<int, IScrollsReward> InitSeventy()
        {
            return m_SeventyLevels = new Dictionary<int, IScrollsReward>()
                {
                    {1, m_Scrolls.FiftyMil},
                    {2, m_Scrolls.FiftyMil},
                    {3, m_Scrolls.FiftyMil},
                    {4, m_Scrolls.FiftyMil},
                    {5, m_Scrolls.FiftyMil},
                    {6, m_Scrolls.HundredMil},
                    {7, m_Scrolls.HundredMil},
                    {8, m_Scrolls.HundredMil},
                    {9, m_Scrolls.HundredMil},
                    {10, m_Scrolls.HundredMil},
                    {11, m_Scrolls.HundredFortyMil},
                    {12, m_Scrolls.HundredFortyMil},
                    {13, m_Scrolls.HundredFortyMil},
                    {14, m_Scrolls.HundredFortyMil},
                    {15, m_Scrolls.HundredFortyMil},
                    {16, m_Scrolls.HundredFortyMil},
                    {17, m_Scrolls.HundredFortyMil},
                    {18, m_Scrolls.HundredFortyMil},
                    {19, m_Scrolls.HundredFortyMil},
                    {20, m_Scrolls.HundredFortyMil},
                    {21, m_Scrolls.HundredFortyMil},
                    {22, m_Scrolls.HundredFortyMil},
                    {23, m_Scrolls.HundredFortyMil},
                    {24, m_Scrolls.HundredFortyMil},
                    {25, m_Scrolls.HundredFortyMil}
                };
        }
        private IReadOnlyDictionary<int, IScrollsReward> InitSeventySeven()
        {
            return m_SeventySevenLevels = new Dictionary<int, IScrollsReward>()
            {
                {1, m_Scrolls.FiftyMil},
                {2, m_Scrolls.FiftyMil},
                {3, m_Scrolls.FiftyMil},
                {4, m_Scrolls.FiftyMil},
                {5, m_Scrolls.FiftyMil},
                {6, m_Scrolls.HundredMil},
                {7, m_Scrolls.HundredMil},
                {8, m_Scrolls.HundredMil},
                {9, m_Scrolls.HundredMil},
                {10, m_Scrolls.HundredMil},
                {11, m_Scrolls.HundredFortyMil},
                {12, m_Scrolls.HundredFortyMil},
                {13, m_Scrolls.HundredFortyMil},
                {14, m_Scrolls.HundredFortyMil},
                {15, m_Scrolls.HundredFortyMil},
                {16, m_Scrolls.ThreeHundredMil},
                {17, m_Scrolls.ThreeHundredMil},
                {18, m_Scrolls.ThreeHundredMil},
                {19, m_Scrolls.ThreeHundredMil},
                {20, m_Scrolls.ThreeHundredMil},
                {21, m_Scrolls.ThreeHundredMil},
                {22, m_Scrolls.ThreeHundredMil},
                {23, m_Scrolls.ThreeHundredMil},
                {24, m_Scrolls.ThreeHundredMil},
                {25, m_Scrolls.ThreeHundredMil}
            };
        }
        private IReadOnlyDictionary<int, IScrollsReward> InitSeventyEightSeven()
        {
            return m_SeventyEightLevels = new Dictionary<int, IScrollsReward>()
            {
                {1, m_Scrolls.EightyMil},
                {2, m_Scrolls.EightyMil},
                {3, m_Scrolls.EightyMil},
                {4, m_Scrolls.EightyMil},
                {5, m_Scrolls.EightyMil},
                {6, m_Scrolls.HundredTwentyMil},
                {7, m_Scrolls.HundredTwentyMil},
                {8, m_Scrolls.HundredTwentyMil},
                {9, m_Scrolls.HundredTwentyMil},
                {10, m_Scrolls.HundredTwentyMil},
                {11, m_Scrolls.TwoHundredMil},
                {12, m_Scrolls.TwoHundredMil},
                {13, m_Scrolls.TwoHundredMil},
                {14, m_Scrolls.TwoHundredMil},
                {15, m_Scrolls.TwoHundredMil},
                {16, m_Scrolls.ThreeHundredFiftyMil},
                {17, m_Scrolls.ThreeHundredFiftyMil},
                {18, m_Scrolls.ThreeHundredFiftyMil},
                {19, m_Scrolls.ThreeHundredFiftyMil},
                {20, m_Scrolls.ThreeHundredFiftyMil},
                {21, m_Scrolls.SixHundredMil},
                {22, m_Scrolls.SixHundredMil},
                {23, m_Scrolls.SixHundredMil},
                {24, m_Scrolls.SixHundredMil},
                {25, m_Scrolls.SixHundredMil}
            };
        }
    }
}
