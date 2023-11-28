using UnityEngine;
using System.Collections;

namespace GDD
{
    public class BikeWeapon_Decorator : MonoBehaviour
    {
        public WeaponConfig weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment secondaryAttachment;

        private bool _isFiring;
        private IWeapon _weapon;
        private bool _isDecorated;

        void Start()
        {
            _weapon = new Weapon(weaponConfig);
        }

        void OnGUI()
        {
            GUI.color = Color.green;

            GUI.Label (new Rect(5, 50, 350, 100), " Range: " +_weapon.Range);
            GUI.Label (new Rect(5, 70, 350, 100),  " Strength: " +_weapon.Strength);

            GUI.Label (new Rect(5, 90, 350, 100),  " Cooldown: " +_weapon.Cooldown);

            GUI.Label (new Rect(5, 110, 350, 100),  " Firing Rate: " +_weapon.Rate);

            GUI.Label (new Rect(5, 130, 350, 100),  " Weapon Firing: " +_isFiring);

            GUI.Label (new Rect(5, 150, 400, 100),  " Weapon Color : " +_weapon.weapon_color);
            
            if (mainAttachment && _isDecorated)
                GUI.Label (new Rect(5, 170, 450, 100),  " Main Attachment: " +mainAttachment.name);

            if (secondaryAttachment && _isDecorated)
                GUI.Label (new Rect(5, 190, 400, 100),  " Secondary Attachment: " +secondaryAttachment.name);
        }

        public void ToggleFire()
        {
            _isFiring = !_isFiring;

            if (_isFiring)
                StartCoroutine(FireWeapon());
        }

        IEnumerator FireWeapon()
        {
            float firingRate = 1.0f / _weapon.Rate;

            while (_isFiring)
            {
                GameObject bullet = Instantiate(_weapon.bullet);
                bullet.transform.position = transform.position;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _weapon.Strength, ForceMode.Impulse);
                Destroy(bullet, 3.0f);
                
                yield return new WaitForSeconds(firingRate);
                Debug.Log("fire");
            }
        }

        public void Reset()
        {
            _weapon = new Weapon(weaponConfig);
            _isDecorated = !_isDecorated;
        }

        public void Decorate()
        {
            if (mainAttachment && !secondaryAttachment)
                _weapon = new WeaponDecorator(_weapon, mainAttachment);

            if (mainAttachment && secondaryAttachment)
                _weapon = new WeaponDecorator(new WeaponDecorator(_weapon, mainAttachment), secondaryAttachment);

            _isDecorated = !_isDecorated;
        }
    }
}