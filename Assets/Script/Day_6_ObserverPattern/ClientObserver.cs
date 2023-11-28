using UnityEngine;

namespace GDD
{
    public class ClientObserver : MonoBehaviour
    {
        private BikeController_ObserverPattern _bikeController;

        void Start()
        {
            _bikeController =
                (BikeController_ObserverPattern)
                FindObjectOfType(typeof(BikeController_ObserverPattern));
        }

        void OnGUI()
        {
            if (GUILayout.Button("Damage Bike"))
                if (_bikeController)
                    _bikeController.TakeDamage(15.0f);

            if(GUILayout.Button("Turn Forward"))
                if (_bikeController)
                    _bikeController.Turn(BikeTurn.Forward);
            
            if(GUILayout.Button("Turn Left"))
                if (_bikeController)
                    _bikeController.Turn(BikeTurn.Left);
            
            if(GUILayout.Button("Turn Right"))
                if (_bikeController)
                    _bikeController.Turn(BikeTurn.Rifht);

            if (GUILayout.Button("Toggle Turbo"))
                if (_bikeController)
                    _bikeController.ToggleTurbo();
        }
    }
}