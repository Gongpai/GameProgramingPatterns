using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public class Spinner_Spinning_State : MonoBehaviour, ISpinner_State
    {
        private float _turnRotation;
        private Spinner_Controller _spinnerController;
        public void Handle(Spinner_Controller controller)
        {
            if (!_spinnerController)
            {
                _spinnerController = controller;
            }

            _spinnerController.CurrentSpeed = 0;
            _spinnerController.CurrentSpeed = _spinnerController.SpeedTimePerSec;
            _turnRotation = (float)_spinnerController.CurrentTurnRotation;
        }

        private void Update()
        {
            if (_spinnerController)
            {
                if (_spinnerController.CurrentAxisRotation == SpinnerAxisRotation.X_Axis)
                {
                    transform.Rotate(_spinnerController.CurrentSpeed * _turnRotation * Time.deltaTime, 0, 0);
                }
                else
                {
                    transform.Rotate(0, _spinnerController.CurrentSpeed * _turnRotation * Time.deltaTime, 0);
                }
            }
        }
    }
}