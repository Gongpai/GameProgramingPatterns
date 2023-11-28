using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public class ClientDecorator : MonoBehaviour
    {
        private BikeWeapon_Decorator _bikeWeapon;
        private bool _isWeaponDecorated;

        void Start()
        {
            _bikeWeapon =
                (BikeWeapon_Decorator)
                FindObjectOfType(typeof(BikeWeapon_Decorator));
        }

        void OnGUI()
        {
            if (!_isWeaponDecorated)
                if (GUILayout.Button("Decorate Weapon"))
                {
                    _bikeWeapon.Decorate();
                    _isWeaponDecorated = !_isWeaponDecorated;
                }

            if (_isWeaponDecorated)
                if (GUILayout.Button("Reset Weapon"))
                {
                    _bikeWeapon.Reset();
                    _isWeaponDecorated = !_isWeaponDecorated;
                }

            if (GUILayout.Button("Toggle Fire"))
                _bikeWeapon.ToggleFire();
        }
    }
}