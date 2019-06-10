using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.DataAccessLayer
{
    internal interface IExpScrollsRepository
    {
        IScrollsReward TenMil { get; }
        IScrollsReward ThirtyMil { get; }
        IScrollsReward FiftyMil{ get; }
        IScrollsReward EightyMil { get; }
        IScrollsReward HundredMil { get; }
        IScrollsReward HundredTwentyMil { get; }
        IScrollsReward HundredFortyMil { get; }
        IScrollsReward TwoHundredMil { get; }
        IScrollsReward ThreeHundredMil { get; }
        IScrollsReward ThreeHundredFiftyMil { get; }
        IScrollsReward FourHundredMil { get; }
        IScrollsReward SixHundredMil { get; }

    }
}
