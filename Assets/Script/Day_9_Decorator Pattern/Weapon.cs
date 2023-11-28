using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public class Weapon : IWeapon
    {
        public float Range
        {
            get { return _config.Range; }
        }

        public float Rate
        {
            get { return _config.Rate; }
        }

        public float Strength
        {
            get { return _config.Strength; }
        }

        public GameObject bullet
        {
            get => _config.weaponPrefab;
        }

        public float Cooldown
        {
            get { return _config.Cooldown; }
        }

        public Color weapon_color
        {
            get => _config.color;
        }

        private readonly WeaponConfig _config;

        public Weapon(WeaponConfig weaponConfig)
        {
            _config = weaponConfig;
        }
    }
}
