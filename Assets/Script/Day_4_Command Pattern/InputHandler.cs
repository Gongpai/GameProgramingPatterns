using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GDD
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private bool _isReplaying;
        private bool _isRecording;
        private BikeController3 _bikeController;
        private Command _buttonA , _buttonD , _buttonW , _buttonQ , _buttonE;
        private SaveManager SM;

        void Start()
        {
            SM = SaveManager.Instance;
            
            _invoker = gameObject.AddComponent <Invoker >();
            _bikeController = FindObjectOfType <BikeController3>();
            _invoker.Controller = _bikeController;
    
            _buttonA = new Command_TurnLeft(_bikeController);
            _buttonD = new Command_TurnRight(_bikeController);
            _buttonW = new Command_ToggleTurbo(_bikeController);
            _buttonQ = new Command_SpinLeft(_bikeController);
            _buttonE = new Command_SpinRight(_bikeController);
            
        }

        void Update()
        {
            if (!_isReplaying && _isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                    _invoker.ExecuteCommand(_buttonA);
        
                if (Input.GetKeyUp(KeyCode.D))
                    _invoker.ExecuteCommand(_buttonD);
        
                if (Input.GetKeyUp(KeyCode.W))
                    _invoker.ExecuteCommand(_buttonW);
                
                if (Input.GetKeyUp(KeyCode.Q))
                    _invoker.ExecuteCommand(_buttonQ);
                
                if (Input.GetKeyUp(KeyCode.E))
                    _invoker.ExecuteCommand(_buttonE);
            }
        }

        void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                _bikeController.ResetPosition();
                _bikeController.StartStopRece(true);
                _isReplaying = false;
                _isRecording = true;
                _invoker.Record();
            }
    
            if (GUILayout.Button("Stop Recording"))
            {
                _bikeController.ResetPosition();
                _bikeController.StartStopRece(false);
                _invoker.SaveReplay();
                _isRecording = false;
            }
    
            if (!_isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    _bikeController.ResetPosition();
                    _bikeController.StartStopRece(!_isRecording);
                    _isRecording = false;
                    _isReplaying = true;
                    _invoker.Replay();
                }
            }

            if (SM.GetDataSaveGames().Count > 0)
            {
                List<FileInfo> infos = SM.GetDataSaveGames();

                int i = 0;
                List<FileInfo> reverse_Fileinfo = infos;
                reverse_Fileinfo.Reverse();
                foreach (var fileInfo in reverse_Fileinfo)
                {
                    i++;
                    string textbutton = fileInfo.Name.Split('.')[0];
                    if (GUILayout.Button(i + ". " + textbutton))
                    {
                        _bikeController.ResetPosition();
                        _bikeController.StartStopRece(!_isRecording);
                        _isRecording = false;
                        _isReplaying = true;
                        _invoker.Replay(true, textbutton);
                    }
                }
            }
        }
    }
}