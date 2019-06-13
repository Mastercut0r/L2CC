using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.Core.Interfaces.DataAccess
{
    public interface IEpicRewardRepository
    {
        IReadOnlyDictionary<int, IScrollsReward> LoadEpicRewardTable<EpicReward>() where EpicReward : IEpicReward;
    }
}
