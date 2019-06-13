using L2CC.Core.Interfaces.Entities;

namespace L2CC.Core.Interfaces.DataAccess
{
    interface IInstanceRewardProvider
    {
        IEpicReward LoadRewardRepository<EpicInstance>() where EpicInstance : IEpicReward;
        IClanArena LoadClanArena();
    }
}
