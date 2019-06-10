using L2CC.Core.Interfaces.Entities;
using L2CC.Core.Interfaces.Entities.Scrolls;
using System;

namespace L2CC.Core.Entities.Scrolls
{
    internal class EnhancementScrollFactory : IEnhancementScrollFactory
    {
        public IEnhancementScroll CreateScroll(WeaponGrade weaponGrade)
        {
            switch (weaponGrade)
            {
                case WeaponGrade.D:
                case WeaponGrade.C:
                case WeaponGrade.B:
                case WeaponGrade.A:
                    return new EnhanceWeaponDCBA();
                case WeaponGrade.S:
                    return new EnhanceWeaponS();
                default:
                    throw new ArgumentException($"{nameof(weaponGrade)} is not implemented");
            }
        }
    }
}
