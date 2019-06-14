using L2CC.Core.DomainLogic.Strategy;
using L2CC.Core.Interfaces.Entities;
using L2CC.Core.Interfaces.Entities.Scrolls;

namespace L2CC.Core.Interfaces.DomainLogic
{
    public interface IExpingCalculator
    {
        /// <summary>
        /// Calculates the exping.
        /// </summary>
        /// <param name="startLevel">The start level.</param>
        /// <param name="targetLevel">The target level.</param>
        /// <param name="gainedExpPercentage">The gained exp percentage.</param>
        /// <param name="startBossStage">The start boss stage.</param>
        /// <param name="endBossStage">The end boss stage.</param>
        /// <param name="isClanArena">if set to <c>true</c> [is clan arena].</param>
        /// <param name="isBaium">if set to <c>true</c> [is baium].</param>
        /// <param name="isZaken">if set to <c>true</c> [is zaken].</param>
        /// <param name="isAntharas">if set to <c>true</c> [is antharas].</param>
        /// <param name="isDailyQuest">if set to <c>true</c> [is DailyQuest].</param>
        /// <param name="instanceEntranceFee">The instance entrance fee.</param>
        /// <param name="strategyFactory">The strategyFactory. For unit testing purposes</param>
        /// <returns>LevelingContainer.</returns>
        ILevelingContainer CalculateExping(
            IStrategyFactory strategyFactory,
            int startLevel,
            int targetLevel,
            double gainedExpPercentage,
            int startBossStage,
            int endBossStage,
            bool isClanArena = false,
            bool isBaium = false,
            bool isZaken = false,
            bool isAntharas = false,
            bool isDailyQuest = false,
            int instanceEntranceFee = 0);

        /// <summary>
        /// Converts the scrolls to level.
        /// </summary>
        /// <param name="startLevel">The start level.</param>
        /// <param name="gainedExpPercentage">The gained exp percentage.</param>
        /// <param name="scrolls">The scrolls.</param>
        /// <returns>ICalculationResultMinimal.</returns>
        IExpingResultMinimal ConvertScrollsToLevel(
            int startLevel,
            double gainedExpPercentage,
            IScrollsReward scrolls);
    }
}
