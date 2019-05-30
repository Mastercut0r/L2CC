﻿using L2CC.Core.Entities;

namespace L2CC.Core.Interfaces.Entities
{
    public interface IWeapon
    {
        string WeaponName { get; }
        double SsBonus { get; }
        WeaponType Type { get; }
        (int patack, int matack) BaseStats { get; }
        (int patack, int matack) FinalStats { get; }
        (int patack, int matack) EnhanceWeapon(int enhancementLevel);
    }
}
