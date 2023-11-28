using UnityEngine;

namespace GDD
{
    public class CameraController : Observer
    {
        private bool _isTurboOn;
        private Vector3 _initialPosition;
        private float _shakeMagnitude = 0.1f;
        private BikeController_ObserverPattern _bikeController;

        void OnEnable()
        {
            _initialPosition =
                gameObject.transform.localPosition;
        }

        void Update()
        {
            if (_isTurboOn)
            {
                gameObject.transform.localPosition =
                    _initialPosition +
                    (Random.insideUnitSphere * _shakeMagnitude);
            }
        }

        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController =
                    subject.GetComponent<BikeController_ObserverPattern>();

            if (_bikeController)
                _isTurboOn = _bikeController.IsTurboOn;
        }
    }
}