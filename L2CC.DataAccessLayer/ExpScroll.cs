using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.DataAccessLayer
{
    public class ExpScrolls : IScrollsReward
    {
        public int TenKkScrollCount { get; private set; }

        public int FiftyKkScrollCount { get; private set; }

        public int HundredKkScrollCount { get; private set; }

        public ulong TotalExp { get; private set; }

        public ulong TotalMoney { get; private set; }

        public int OneMillDailyScrollsCount { get; private set; }

        public int TenMillDailyScrollsCount { get; private set; }

        public ExpScrolls(
            int tenKkScrollCount,
            int fiftyKkScrollCount,
            int hundredKkScrollCount,
            int oneMillDailyScrollsCount,
            int tenMillDailyScrollscount)
        {
            TenKkScrollCount = tenKkScrollCount;
            FiftyKkScrollCount = fiftyKkScrollCount;
            HundredKkScrollCount = hundredKkScrollCount;

            OneMillDailyScrollsCount = oneMillDailyScrollsCount;
            TenMillDailyScrollsCount = tenMillDailyScrollscount;

            TotalExp = CalculateTotalExp();
            TotalMoney = CalculateTotalMoney();
        }

        public ExpScrolls(
            int tenKkScrollCount,
            int fiftyKkScrollCount,
            int hundredKkScrollCount)
            : this(tenKkScrollCount, fiftyKkScrollCount, hundredKkScrollCount, 0, 0)
        { }

        public ExpScrolls(
            int oneMillDailyScrolls,
            int tenMillDailyScrolls)
            : this(0, 0, 0, oneMillDailyScrolls, tenMillDailyScrolls)
        { }

        private ulong CalculateTotalExp()
        {
            return (uint)TenKkScrollCount * ExpScrollConstants.tenMillExp +
                (uint)FiftyKkScrollCount * ExpScrollConstants.fiftyMillExp +
                (uint)HundredKkScrollCount * ExpScrollConstants.hundredMillExp +
                (uint)OneMillDailyScrollsCount * ExpScrollConstants.millExp +
                (uint)TenMillDailyScrollsCount * ExpScrollConstants.tenMillExp;
        }

        private ulong CalculateTotalMoney()
        {
            return (uint)TenKkScrollCount * ExpScrollConstants.tenMilScrollPrice +
                (uint)FiftyKkScrollCount * ExpScrollConstants.fiftyMilScrollPrice +
                (uint)HundredKkScrollCount * ExpScrollConstants.hundredMilScrollPrice;
        }

        //public static ExpScrolls operator +(ExpScrolls firstReward, ExpScrolls secondReward)
        //{
        //    int oneDaily = firstReward.OneMillDailyScrolls + secondReward.OneMillDailyScrolls;
        //    int tenDaily = firstReward.TenMillDailyScrolls + secondReward.TenMillDailyScrolls;

        //    int ten = firstReward.TenKkScrollCount + secondReward.TenKkScrollCount;
        //    int fifty = firstReward.FiftyKkScrollCount + secondReward.FiftyKkScrollCount;
        //    int hundred = firstReward.HundredKkScrollCount + secondReward.HundredKkScrollCount;
        //    return new ExpScrolls(ten, fifty, hundred, oneDaily, tenDaily);
        //}
        public static IScrollsReward CreateEmptyContainer()
        {
            return new ExpScrolls(0, 0, 0);
        }

        public void AddScrolls(IScrollsReward scrolls)
        {
            OneMillDailyScrollsCount += scrolls.OneMillDailyScrollsCount;
            TenMillDailyScrollsCount += scrolls.TenMillDailyScrollsCount;

            TenKkScrollCount += scrolls.TenKkScrollCount;
            FiftyKkScrollCount += scrolls.FiftyKkScrollCount;
            HundredKkScrollCount += scrolls.HundredKkScrollCount;
        }

        public static IScrollsReward Empty()
        {
            return new ExpScrolls(0, 0);
        }
    }
}
