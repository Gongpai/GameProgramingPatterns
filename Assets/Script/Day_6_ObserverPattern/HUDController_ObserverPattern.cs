using UnityEngine;

namespace GDD
{
    public class HUDController_ObserverPattern : Observer
    {
        private BikeTurn _bikeTurn = BikeTurn.Forward;
        private bool _isTurboOn;
        private float _currentHealth;
        private BikeController_ObserverPattern _bikeController;

        void OnGUI()
        {
            GUILayout.BeginArea(
                new Rect(100, 10, 100, 200));

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health: " +_currentHealth);
            GUILayout.EndHorizontal();

            switch (_bikeTurn)
            {
                case BikeTurn.Forward:
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label("Forward ^");
                    GUILayout.EndHorizontal();
                    break;
                case BikeTurn.Left:
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label("Left <");
                    GUILayout.EndHorizontal();
                    break;
                case BikeTurn.Rifht:
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label("Right >");
                    GUILayout.EndHorizontal();
                    break;
            }
            
            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated!");
                GUILayout.EndHorizontal();
            }

            if (_currentHealth <= 50.0f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("WARNING: Low Health");
                GUILayout.EndHorizontal();
            }

            GUILayout.EndArea();
        }

        public override void Notify(Subject subject)
        {
            if (!_bikeController)

                _bikeController =
                    subject.GetComponent<BikeController_ObserverPattern>();

            if (_bikeController)
            {
                _isTurboOn =
                    _bikeController.IsTurboOn;

                _currentHealth =
                    _bikeController.CurrentHealth;

                _bikeTurn = _bikeController._BikeTurn;
            }
        }
    }
}