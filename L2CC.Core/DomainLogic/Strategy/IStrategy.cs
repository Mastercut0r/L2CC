using L2CC.Core.Interfaces.Entities;

namespace L2CC.Core.DomainLogic.Strategy
{
    public interface IStrategy
    {
        void Apply(ILevelingContainer container);
    }
}
