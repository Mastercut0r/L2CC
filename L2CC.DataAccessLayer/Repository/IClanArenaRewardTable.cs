using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.DataAccessLayer.Repository
{
    interface IClanArenaRewardTable
    {
        IReadOnlyDictionary<int, IScrollsReward> LoadRewardTableForLevel(int level);
    }
}
