using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace GDD
{
    public class BikeController : MonoBehaviour
    {
        [SerializeField]private float maxSpeed = 2.0f;
        [SerializeField]private float trunDistance = 2.0f;
        [SerializeField]private float currentSpeed;
        [FormerlySerializedAs("currentTurnDirection")] [SerializeField]private BikeDirection currentTurnBikeDirection;

        public float MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }
        
        public float TurnDistance
        {
            get { return trunDistance; }
            set { trunDistance = value; }
        }
        
        public float CurrentSpeed
        {
            get { return currentSpeed; }
            set { currentSpeed = value; }
        }

        public BikeDirection CurrentTurnBikeDirection
        {
            get { return currentTurnBikeDirection; }
            set { currentTurnBikeDirection = value; }
        }
        
        private IBikeState _startState, _stopState, _turnState;

        private BikeStateContext _bikeStateContext;

        private void Start()
        {
            _bikeStateContext = new BikeStateContext(this);

            _startState = gameObject.AddComponent<BikeState_Start>();
            _stopState = gameObject.AddComponent<BikeState_Stop>();
            _turnState = gameObject.AddComponent<BikeState_Turn>();
        }

        public void StartBike()
        {
            _bikeStateContext.Transition(_startState);
        }

        public void StopBike()
        {
            _bikeStateContext.Transition(_stopState);
        }

        public void Turn(BikeDirection bikeDirection)
        {
            CurrentTurnBikeDirection = bikeDirection;
            _bikeStateContext.Transition(_turnState);
        }
    }
}
