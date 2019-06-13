using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities.EpicInstances;
using L2CC.Core.Interfaces.Entities.Scrolls;
using L2CC.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;

namespace L2CC.DataAccessLayer.EpicInstances
{
    internal class EpicRewardRepository : IEpicRewardRepository
    {
        public IReadOnlyDictionary<int, IScrollsReward> LoadEpicRewardTable<EpicReward>() where EpicReward : IEpicReward
        {
            if (typeof(EpicReward) == typeof(IBaiumReward))
            {
                return new BaiumRewardTable().LoadRewardTable();
            }
            if (typeof(EpicReward) == typeof(IAntharasReward))
            {
                return new BaiumRewardTable().LoadRewardTable();
            }
            if (typeof(EpicReward) == typeof(IZakenReward))
            {
                return new BaiumRewardTable().LoadRewardTable();
            }
            throw new NotSupportedException(nameof(EpicReward));
        }
    }
}
