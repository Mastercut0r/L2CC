namespace L2CC.Core.Interfaces.DataAccess
{
    interface IEpicInstancesProvider
    {
        IEpicRewardRepository LoadRewardRepository<EpicInstance>() where EpicInstance : IEpicRewardRepository;
    }
}
