using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GDD
{
    public class Spinner_Controller : MonoBehaviour
    {
        [SerializeField]private float m_Speed = 60;
        private SpinnerTurnRotation mCurrentTurnRotation;
        private SpinnerAxisRotation mCurrentAxisRotation;
        private float m_speedTimePerSec;
        private float m_currentSpeed;
        
        public float CurrentSpeed
        {
            get { return m_currentSpeed; }
            set { m_currentSpeed = value; }
        }

        public float SpeedTimePerSec
        {
            get => m_speedTimePerSec;
            set => m_speedTimePerSec = value;
        }

        public SpinnerTurnRotation CurrentTurnRotation
        {
            get { return mCurrentTurnRotation; }
            set { mCurrentTurnRotation = value; }
        }

        public SpinnerAxisRotation CurrentAxisRotation
        {
            get => mCurrentAxisRotation;
            set => mCurrentAxisRotation = value;
        }
        
        private ISpinner_State _spinner_Spinning_State, _spinner_Stop_State, _spinner_Jump_State;

        private Spinner_Context _spinnerContext;
        
        private void Start()
        {
            _spinnerContext = new Spinner_Context(this);
            
            _spinner_Spinning_State = gameObject.AddComponent<Spinner_Spinning_State>();
            _spinner_Stop_State = gameObject.AddComponent<Spiner_Stop_State>();

            m_speedTimePerSec = m_Speed * 360;
            m_currentSpeed = m_speedTimePerSec;
        }

        public void Rotaion_Axis(SpinnerTurnRotation spinnerTurnRotation, SpinnerAxisRotation spinnerAxisRotation)
        {
            CurrentTurnRotation = spinnerTurnRotation;
            CurrentAxisRotation = spinnerAxisRotation;
            _spinnerContext.Transition(_spinner_Spinning_State);
        }

        public void stop()
        {
            _spinnerContext.Transition(_spinner_Stop_State);
        }
    }
}
