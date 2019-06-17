using L2CC.Core.DomainLogic.Strategy;
using L2CC.Core.Entities;
using L2CC.Core.Interfaces.DataAccess;
using L2CC.Core.Interfaces.DomainLogic;
using L2CC.Core.Interfaces.Entities;
using L2CC.Core.Interfaces.Entities.Scrolls;
using System;
using System.Collections.Generic;

namespace L2CC.Core.DomainLogic
{
    class InstanceExpingCalculator : IExpingCalculator
    {
        /// <summary>
        /// Calculates all relevant data and puts them in a container
        /// </summary>
        /// <param name="experienceRepository">The experienceRepository</param>
        /// <param name="strategies">The strategies</param>
        /// <param name="container">The container with level inputs.</param>
        /// <returns>returns data container if arguments are valid. Otherwise returns light weight container with total experience only</returns>
        public ILevelingContainer CalculateExping(
            IExperienceRepository experienceRepository,
            IReadOnlyCollection<IStrategy> strategies,
            InputLevelContainer levelContainer)
        {
            if (levelContainer.StartLevel > levelContainer.TargetLevel) return null;
            ulong totalExperience = CalculateTotalExp(experienceRepository, levelContainer.StartLevel, levelContainer.TargetLevel, levelContainer.GainedExpPercentage);
            if (strategies.Count == 0) return new LevelingContainer(totalExperience, levelContainer.StartLevel);
            var container = new LevelingContainer(totalExperience, levelContainer.StartLevel);
            return ApplyStrategies(
                strategies,
                container);
        }

        private ILevelingContainer ApplyStrategies(
            IReadOnlyCollection<IStrategy> strategies,
            ILevelingContainer container)
        {
            bool calculationNeeded = true;
            while (calculationNeeded)
            {
                var tempExpMark = container.RemainingExperience;
                foreach (var strategy in strategies)
                {
                    strategy.Apply(container);
                }
                container.WeeklyCyclesNeeded++;
                if (tempExpMark - container.RemainingExperience == 0)
                {
                    calculationNeeded = false;
                    container.WeeklyCyclesNeeded -= 1;
                }
            }
            return container;
        }

        private ulong CalculateTotalExp(IExperienceRepository repository, int startLevel, int targetLevel, double gainedExpPercentage)
        {
            if (startLevel >= targetLevel)
                return 0;

            ulong expNeeded = 0;
            if (startLevel < targetLevel)
            {
                for (ushort lvl = (ushort)(startLevel + 1); lvl <= targetLevel; lvl++)
                {
                    expNeeded += repository.GetExperience(lvl);
                }
            }
            expNeeded -= (ulong)(repository.GetExperience(startLevel + 1) * (gainedExpPercentage / 100));
            return expNeeded;
        }

        public IExpingResultMinimal ConvertScrollsToLevel(
            IExperienceRepository repository,
            int startLevel,
            double gainedExpPercentage,
            IScrollsReward scrolls)
        {
            if (!repository.IsLevelUpPossible(startLevel)) return new ResultMinimal(startLevel);
            int currentLevel = startLevel;
            ulong expToConvert = scrolls.TotalExp;
            ulong expOnLevel = CalculateGainedExpOnLevel(repository, startLevel, gainedExpPercentage);
            if (expToConvert == 0)
            {
                return new ResultMinimal(startLevel, expOnLevel, gainedExpPercentage);
            }
            expToConvert += expOnLevel;
            while (repository.IsLevelUpPossible(currentLevel) && expToConvert >= repository.GetExperience(currentLevel + 1))
            {
                currentLevel++;
                expToConvert -= repository.GetExperience(currentLevel);
            };
            var gainedPercentage = CalculateExpPercentage(repository, expToConvert, currentLevel);
            return new ResultMinimal(currentLevel, expToConvert, gainedPercentage);
        }

        private ulong CalculateGainedExpOnLevel(IExperienceRepository repository, int level, double gainedExpPercentage)
        {
            return (ulong)(repository.GetExperience(level + 1) * (gainedExpPercentage / 100));
        }

        /// <summary>
        /// Sets the exp percentage and rounds it to two digits
        /// </summary>
        private double CalculateExpPercentage(IExperienceRepository repository, double gainedExpOnLevel, int currentLevel)
        {
            var gainedExpPercentageOnLevel = gainedExpOnLevel * 100.00 / repository.GetExperience(currentLevel + 1);
            return Math.Round(gainedExpPercentageOnLevel, 2);
        }
    }
}
