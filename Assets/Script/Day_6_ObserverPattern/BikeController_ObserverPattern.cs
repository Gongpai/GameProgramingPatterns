using UnityEngine;

namespace GDD
{
    public class BikeController_ObserverPattern : Subject
    {
        public bool IsTurboOn { get; private set; }
        public BikeTurn _BikeTurn { get; private set; }

        public float CurrentHealth
        {
            get { return health; }

        }

        public bool _isEngineOn { get; private set; }
        private HUDController_ObserverPattern _hudControllerObserverPattern;
        private CameraController _cameraController;
        private BikeHandleController _bikeHandleController;
        [SerializeField] private float health = 100.0f;

        void Awake()
        {
            _hudControllerObserverPattern =
                gameObject.AddComponent<HUDController_ObserverPattern>();

            _cameraController =
                (CameraController)
                FindObjectOfType(typeof(CameraController));

            _bikeHandleController = FindObjectOfType<BikeHandleController>();
        }

        private void Start()
        {
            StartEngine();
        }

        void OnEnable()
        {
            if (_hudControllerObserverPattern)
                Attach(_hudControllerObserverPattern);

            if (_cameraController)
                Attach(_cameraController);
            
            if(_bikeHandleController)
                Attach(_bikeHandleController);
        }

        void OnDisable()
        {
            if (_hudControllerObserverPattern)
                Detach(_hudControllerObserverPattern);

            if (_cameraController)
                Detach(_cameraController);
            
            if(_bikeHandleController)
                Detach(_bikeHandleController);
        }

        private void StartEngine()
        {
            _isEngineOn = true;

            NotifyObservers();
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn)
                IsTurboOn = !IsTurboOn;

            NotifyObservers();
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            IsTurboOn = false;

            NotifyObservers();
            if (health < 0)
                Destroy(gameObject);
        }

        public void Turn(BikeTurn _turn)
        {
            _BikeTurn = _turn;
            
            NotifyObservers();
        }
    }
}