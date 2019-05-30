using L2CC.Core.Entities;
using L2CC.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace L2CC.Core.DataAccessInterfaces
{
    public interface IWeaponRepository
    {
        IReadOnlyDictionary<string, IWeapon> GetWeapons(WeaponClass weaponClass);
    }
}
