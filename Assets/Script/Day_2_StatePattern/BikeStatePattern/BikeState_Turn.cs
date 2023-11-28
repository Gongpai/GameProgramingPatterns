using UnityEngine;

namespace GDD
{
    public class BikeState_Turn : MonoBehaviour, IBikeState
    {
        private Vector3 _turnDirection;
        private BikeController _bikeController;
        public void Handle(BikeController controller)
        {
            if (!_bikeController)
            {
                _bikeController = controller;
            }

            _turnDirection.x = (float)_bikeController.CurrentTurnBikeDirection;

            if (_bikeController.CurrentSpeed > 0)
            {   
                transform.Translate(_turnDirection*_bikeController.TurnDistance);
            }
        }
    }
}