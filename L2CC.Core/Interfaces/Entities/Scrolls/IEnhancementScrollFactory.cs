namespace L2CC.Core.Interfaces.Entities.Scrolls
{
    internal interface IEnhancementScrollFactory
    {
        IEnhancementScroll CreateScroll(WeaponGrade weaponClass);
    }
}
