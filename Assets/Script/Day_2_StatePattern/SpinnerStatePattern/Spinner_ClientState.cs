using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public class Spinner_ClientState : MonoBehaviour
    {
        private Spinner_Controller _spinnerController;

        // Start is called before the first frame update
        void Start()
        {
            _spinnerController = FindObjectOfType<Spinner_Controller>();
        }

        private void OnGUI()
        {
            if(GUILayout.Button("Stop"))
                _spinnerController.stop();
            if(GUILayout.Button("X Axis Forward"))
                _spinnerController.Rotaion_Axis(SpinnerTurnRotation.forward, SpinnerAxisRotation.X_Axis);
            if(GUILayout.Button("X Axis Revert"))
                _spinnerController.Rotaion_Axis(SpinnerTurnRotation.revert, SpinnerAxisRotation.X_Axis);
            if(GUILayout.Button("Y Axis Forward"))
                _spinnerController.Rotaion_Axis(SpinnerTurnRotation.forward, SpinnerAxisRotation.Y_Axis);
            if(GUILayout.Button("Y Axis Revert"))
                _spinnerController.Rotaion_Axis(SpinnerTurnRotation.revert, SpinnerAxisRotation.Y_Axis);
        }
    }
}
