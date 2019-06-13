using L2CC.DataAccessLayer.Repository;

namespace L2CC.DataAccessLayer
{
    interface IDataContext
    {
        IRewardTable LoadRewardTable<RewardTableType>() where RewardTableType : IRewardTable;
    }
}
