using L2CC.Core.Entities;
using L2CC.Core.Interfaces.Entities.Scrolls;
using L2CC.DataAccessLayer.Repository;

namespace L2CC.DataAccessLayer
{
    class ExpScrollsRepository : IExpScrollsRepository
    {
        private IScrollsReward m_tenMil = new ExpScrolls(1, 0, 0);
        private IScrollsReward m_thirtyMil = new ExpScrolls(3, 0, 0);
        private IScrollsReward m_fiftyMil = new ExpScrolls(0, 1, 0);
        private IScrollsReward m_eightyMil = new ExpScrolls(3, 1, 0);
        private IScrollsReward m_hundredMil = new ExpScrolls(0, 0, 1);
        private IScrollsReward m_hundredTwentyMil = new ExpScrolls(2, 0, 1);
        private IScrollsReward m_hundredFortyMil = new ExpScrolls(4, 0, 1);
        private IScrollsReward m_twoHundredMil = new ExpScrolls(0, 0, 2);
        private IScrollsReward m_threeHundredMil = new ExpScrolls(0, 0, 3);
        private IScrollsReward m_threeHundredFiftyMil = new ExpScrolls(0, 1, 3);
        private IScrollsReward m_fourHundredMil = new ExpScrolls(0, 0, 4);
        private IScrollsReward m_sixHundredMil = new ExpScrolls(0, 0, 6);
        private IScrollsReward m_EmptyContainer = new ExpScrolls(0, 0, 0);

        public IScrollsReward TenMil => m_tenMil;

        public IScrollsReward ThirtyMil => m_thirtyMil;

        public IScrollsReward FiftyMil => m_fiftyMil;

        public IScrollsReward EightyMil => m_eightyMil;

        public IScrollsReward HundredMil => m_hundredMil;

        public IScrollsReward HundredTwentyMil => m_hundredTwentyMil;

        public IScrollsReward HundredFortyMil => m_hundredFortyMil;

        public IScrollsReward TwoHundredMil => m_twoHundredMil;

        public IScrollsReward ThreeHundredMil => m_threeHundredMil;

        public IScrollsReward ThreeHundredFiftyMil => m_threeHundredFiftyMil;

        public IScrollsReward FourHundredMil => m_fourHundredMil;

        public IScrollsReward SixHundredMil => m_sixHundredMil;

        public IScrollsReward Empty => m_eightyMil;
    }
}
