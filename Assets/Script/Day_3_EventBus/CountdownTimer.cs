using System.Collections;
using UnityEngine;

namespace GDD
{
 public class CountdownTimer : MonoBehaviour
 {
  [SerializeField] private float _currentTime;
  [SerializeField] private float _duration = 3.0f;

  private void OnEnable()
  {
   RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
  }

  private void OnDisable()
  {
   RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
  }

  private void StartTimer()
  {
   StartCoroutine(Countdown());
  }

  private IEnumerator Countdown()
  {
   _currentTime = _duration;

   while (_currentTime > 0)
   {
    yield return new WaitForSeconds(1f);
    _currentTime--;
   }

   RaceEventBus.Publish(RaceEventType.START);
  }

  void OnGUI()
  {
   // if (GUILayout.Button(”Start Timer”))
   // {
   // StartTimer();
   // }
   GUI.color = Color.blue;
   GUI.Label(new Rect(125, 0, 100, 20), "COUNTDOWN: " + _currentTime);
  }

 }
}