using L2CC.Core.DomainLogic.Strategy;
using L2CC.Core.Entities;
using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.Entities;
using L2CC.Core.Interfaces.Entities.Scrolls;
using System.Collections.Generic;

namespace L2CC.Core.Interfaces.DomainLogic
{
    public interface IExpingCalculator
    {
        /// <summary>
        /// Calculates the exping.
        /// </summary>
        /// <param name="experienceRepository">The experienceRepository</param>
        /// <param name="strategies">The strategies</param>
        /// <param name="container">The container with level inputs.</param>
        /// <returns>LevelingContainer.</returns>
        ILevelingContainer CalculateExping(
            IExperienceRepository experienceRepository,
            IReadOnlyCollection<IStrategy> strategies,
            InputLevelContainer levelContainer);

        /// <summary>
        /// Converts the scrolls to level.
        /// </summary>
        /// <param name="startLevel">The start level.</param>
        /// <param name="gainedExpPercentage">The gained exp percentage.</param>
        /// <param name="scrolls">The scrolls.</param>
        /// <returns>ICalculationResultMinimal.</returns>
        IExpingResultMinimal ConvertScrollsToLevel(
            IExperienceRepository repository,
            int startLevel,
            double gainedExpPercentage,
            IScrollsReward scrolls);
    }
}
