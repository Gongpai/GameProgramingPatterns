using System.Collections;
using System.Collections.Generic;
using GDD;
using UnityEngine;

namespace GDD
{
    public class Spinner_Context : MonoBehaviour
    {
        public ISpinner_State CurrentState { get; set; }

        private readonly Spinner_Controller _spinnerController;

        public Spinner_Context(Spinner_Controller spinnerController)
        {
            _spinnerController = spinnerController;
        }

        public void Transition()
        {
            CurrentState.Handle(_spinnerController);
        }

        public void Transition(ISpinner_State state)
        {
            CurrentState = state;
            CurrentState.Handle(_spinnerController);
        }
    }
}
