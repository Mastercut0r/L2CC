using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.DataAccessLayer.Repository
{
    interface IRewardTable
    {
        IReadOnlyDictionary<int, IScrollsReward> LoadRewardTable();
    }
}
