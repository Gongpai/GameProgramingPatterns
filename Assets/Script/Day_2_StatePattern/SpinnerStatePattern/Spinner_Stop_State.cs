using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public class Spiner_Stop_State : MonoBehaviour, ISpinner_State
    {
        private Spinner_Controller _spinnerController;

        public void Handle(Spinner_Controller controller)
        {
            if (!_spinnerController)
            {
                _spinnerController = controller;
            }

            _spinnerController.CurrentSpeed = 0;
        }
    }
}