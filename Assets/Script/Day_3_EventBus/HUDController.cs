using UnityEngine;

namespace GDD
{
    public class HUDController : MonoBehaviour
    {
        private bool _isDisplayOn;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, DisplayHUD);
        }

        private void DisplayHUD()
        {
            _isDisplayOn = true;
        }

        private void OnGUI()
        {
            if (_isDisplayOn)
            {
                GUILayout.BeginArea(new Rect (0,25,100,100));
                if (GUILayout.Button("Stop Race"))
                {
                    _isDisplayOn = false;
                    RaceEventBus.Publish(RaceEventType.STOP);
                }
                GUILayout.EndArea();
            }
        }
    }
}