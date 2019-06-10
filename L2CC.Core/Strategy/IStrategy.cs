using L2CC.Core.Interfaces.Entities;

namespace L2CC.Core.Strategy
{
    public interface IStrategy
    {
        void Apply(ILevelingContainer container);
    }
}
