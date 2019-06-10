using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.Core.Interfaces.Entities
{
    public interface ILevelingContainer
    {
        ulong TotalExperience { get; set; }
        ulong RemainingExperience { get; set; }
        ulong ExperienceOnLevel { get; set; }
        int WeeklyCyclesNeeded { get; set; }
        int CurrentLevel { get; set; }
        int ArenaRbKillCount { get; set; }
        IScrollsReward CollectedScrolls { get; set; }
    }
}
