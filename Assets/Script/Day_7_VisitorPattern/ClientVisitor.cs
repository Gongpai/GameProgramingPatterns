using UnityEngine;

namespace GDD
{
    public class ClientVisitor : MonoBehaviour
    {
        public PowerUp enginePowerUp;
        public PowerUp shieldPowerUp;
        public PowerUp weaponPowerUp;
        public PowerUp bike_color;

        private BikeControllerVisitorPattern _bikeController;

        void Start()
        {
            _bikeController =
                gameObject.AddComponent<BikeControllerVisitorPattern>();
        }

        void OnGUI()
        {
            if (GUILayout.Button("PowerUp Shield"))
                _bikeController.Accept(shieldPowerUp);

            if (GUILayout.Button("PowerUp Engine"))
                _bikeController.Accept(enginePowerUp);

            if (GUILayout.Button("PowerUp Weapon"))
                _bikeController.Accept(weaponPowerUp);
            
            if (GUILayout.Button("Add Color"))
                _bikeController.Accept(bike_color);
        }
    }
}