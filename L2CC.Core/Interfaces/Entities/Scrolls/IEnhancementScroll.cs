using L2CC.Core.Entities;

namespace L2CC.Core.Interfaces.Entities.Scrolls
{
    internal interface IEnhancementScroll
    {
        (int patack, int matack) GetEnhancementBonus(WeaponClass weaponType);
    }
}
