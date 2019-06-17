namespace L2CC.Core.Entities
{
    public class InputLevelContainer
    {
        public int StartLevel { get; private set; }
        public int TargetLevel { get; private set; }
        public double GainedExpPercentage { get; private set; }
        public InputLevelContainer(int startLevel, int targetLevel, double gainedExpPercentage)
        {
            StartLevel = startLevel;
            TargetLevel = targetLevel;
            GainedExpPercentage = gainedExpPercentage;
        }
    }
}
