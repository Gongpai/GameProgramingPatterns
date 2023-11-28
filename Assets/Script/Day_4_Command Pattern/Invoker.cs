using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GDD
{
    public class Invoker : MonoBehaviour
    {
        private BikeController3 _controller;
        private bool _isRecording;
        private bool _isReplaying;
        private float _replayTime;
        private float _recordingTime;
        private SaveManager SM;

        private SortedList <float, Command > _recordedCommands =
            new SortedList <float, Command >();

        private RecordData _recordData = new RecordData();

        public BikeController3 Controller
        {
            get => _controller;
            set => _controller = value;
        }
        
        public void ExecuteCommand(Command command)
        {
            command.Execute();
    
            if (_isRecording)
                _recordedCommands.Add(_recordingTime , command);
    
            Debug.Log("Recorded Time: " + _recordingTime);
            Debug.Log("Recorded Command: " + command);
        }

        public void Record()
        {
            _recordingTime = 0.0f;
            _isRecording = true;
        }

        public void Replay(bool play_FromSaveData = false, string filename = "")
        {
            _replayTime = 0.0f;
            _isReplaying = true;

            if (play_FromSaveData)
            {
                _recordedCommands = SM.LoadGameData<RecordData>(default, filename).recordedCommands;
                
                foreach (var recorded in _recordedCommands)
                {
                    recorded.Value.set_controller(_controller);
                }
            }

            if (_recordedCommands.Count <= 0)
                Debug.LogError("No commands to replay!");
    
            _recordedCommands.Reverse();
        }

        public void SaveReplay()
        {
            _recordData.recordedCommands = _recordedCommands;
            SM.SaveGameData<RecordData>(_recordData);
        }

        private void Awake()
        {
            SM = SaveManager.Instance;
        }

        void FixedUpdate()
        {
            if (_isRecording)
                _recordingTime += Time.fixedDeltaTime;
    
            if (_isReplaying)
            {
                _replayTime += Time.fixedDeltaTime;
        
                if (_recordedCommands.Any())
                {
                    if (Mathf.Approximately(
                            _replayTime , _recordedCommands.Keys[0]))
                    {
                
                        Debug.Log("Replay Time: " + _replayTime);
                        Debug.Log("Replay Command: "  +
                            _recordedCommands.Values[0]);
                
                        _recordedCommands.Values[0].Execute();
                        _recordedCommands.RemoveAt(0);
                    }
                }
                else
                {
                    _isReplaying = false;
                }
            }
        }
    }
}