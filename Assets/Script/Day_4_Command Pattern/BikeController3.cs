using System;
using UnityEngine;
namespace GDD
{
    public class BikeController3 : MonoBehaviour
    {
        public enum Direction
        {
            Left = -1,
            Right = 1
        }

        [SerializeField]private float forwardspeed = 5;
        private bool _isTurboOn;
        private bool _isStart = false;
        private float _distance = 1.0f;

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
        }

        public void Turn(Direction direction)
        {
            if (direction == Direction.Left)
                transform.Translate(Vector3.left * _distance);
    
            if (direction == Direction.Right)
                transform.Translate(Vector3.right * _distance);
        }
        
        public void Spin(Direction direction)
        {
            if (direction == Direction.Left)
                transform.Rotate(new Vector3(0 ,-5,0));
    
            if (direction == Direction.Right)
                transform.Rotate(new Vector3(0 ,5,0));
        }

        public void StartStopRece(bool isStart)
        {
            _isStart = isStart;
        }
        
        public void ResetPosition()
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            transform.localEulerAngles = Vector3.zero;
        }

        private void Update()
        {
            if (_isStart)
            {
                if (_isTurboOn)
                {
                    transform.position += new Vector3(0,0,1) * (forwardspeed * 2) * Time.deltaTime;
                }
                else
                {
                    transform.position += new Vector3(0,0,1) * (forwardspeed) * Time.deltaTime;
                }
            }
        }
    }
}