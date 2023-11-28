using System;
using UnityEngine;

namespace GDD
{
    public class BikeClientState: MonoBehaviour
    {
        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = FindObjectOfType<BikeController>();
        }

        private void OnGUI()
        {
            if(GUILayout.Button("Start Bike"))
                _bikeController.StartBike();
            if(GUILayout.Button("Turn Left"))
                _bikeController.Turn(BikeDirection.Left);
            if(GUILayout.Button("Turn Right"))
                _bikeController.Turn(BikeDirection.Right);
            if(GUILayout.Button("Stop Bike"))
                _bikeController.StopBike();
        }
    }
}