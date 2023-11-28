using UnityEngine;

namespace GDD
{
    public interface IWeapon
    {
        float Rate { get; }
        float Range { get; }
        float Strength { get; }
        float Cooldown { get; }
        Color weapon_color { get; }
        public GameObject bullet { get; }
    }
}