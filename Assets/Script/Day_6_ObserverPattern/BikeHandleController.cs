using System;
using UnityEngine;

namespace GDD
{
    public class BikeHandleController : Observer
    {
        private BikeTurn _bikeTurn = BikeTurn.Forward;
        private bool _isEngineOn;
        private float speed = 1;
        private BikeController_ObserverPattern _bikeController;

        private void Update()
        {
            if (_isEngineOn)
            {
                OnTurn();
            }
        }

        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController =
                    subject.GetComponent<BikeController_ObserverPattern>();

            if (_bikeController)
            {
                _isEngineOn = _bikeController._isEngineOn;
                _bikeTurn = _bikeController._BikeTurn;

                if (_bikeController.IsTurboOn)
                {
                    speed = 3;
                }
                else
                {
                    speed = 1;
                }
            }
        }

        private void OnTurn()
        {
            switch (_bikeTurn)
            {
                case BikeTurn.Forward:
                    //print("F Moveeeeee");
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    break;
                case BikeTurn.Left:
                    //print("L Moveeeeee");
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                    break;
                case BikeTurn.Rifht:
                    //print("R Moveeeeee");
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                    break;
            }
        }
    }
}