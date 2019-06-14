namespace L2CC.Core.Interfaces.Entities
{
    public interface IExpingResultMinimal
    {
        int ResultLevel { get; }
        double GainedExpPercentageOnLevel { get; }
        ulong GainedExpOnLevel { get; }
    }
}
