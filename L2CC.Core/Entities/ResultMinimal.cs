using L2CC.Core.Interfaces.Entities;
using System;

namespace L2CC.Core.Entities
{
    class ResultMinimal : IExpingResultMinimal
    {
        public ResultMinimal(int resultLevel) : this(resultLevel, 0, 0) { }
        public ResultMinimal(int resultLevel, ulong gainedExpOnLevel, double gainedExpPercentageOnLevel)
        {
            ResultLevel = resultLevel;
            GainedExpOnLevel = gainedExpOnLevel;
            GainedExpPercentageOnLevel = gainedExpPercentageOnLevel;
        }

        public int ResultLevel { get; private set; }

        public double GainedExpPercentageOnLevel { get; private set; }

        public ulong GainedExpOnLevel { get; private set; }
    }
}
