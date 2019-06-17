using L2CC.Core.Interfaces.Entities;
using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.Core.Entities
{
    public class LevelingContainer : ILevelingContainer
    {
        public ulong TotalExperience { get; set; }
        public ulong RemainingExperience { get; set; }
        public int WeeklyCyclesNeeded { get; set; }
        public int ArenaRbKillCount { get; set; }
        public IScrollsReward CollectedScrolls { get; set; }
        public ulong ExperienceOnLevel { get; set; }
        public int CurrentLevel { get; set; }

        public LevelingContainer(ulong totalExperience, int startLevel)
        {
            CurrentLevel = startLevel;
            TotalExperience = totalExperience;
            RemainingExperience = totalExperience;
            CollectedScrolls = ExpScrolls.Empty();
        }
    }
}
