using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GDD
{
    public class FallbackManeuver : MonoBehaviour, IManeuverBehaviour
    {
        private List<GameObject> bullets = new List<GameObject>();
        private Quaternion rot;
        private float current_axis;
        
        public void Maneuver(Drone_StrategyPattern drone)
        {
            StartCoroutine(Fallback(drone));
        }

        IEnumerator Fallback(Drone_StrategyPattern drone)
        {
            float time = 0;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.z = drone.fallbackDistance;

            while (true)
            {
                if (bullets.Count > 0)
                {
                    foreach (var _bullet in bullets)
                    {
                        Destroy(_bullet);
                    }
                }


                Vector3 current_rot = new Vector3();
                current_axis = 0;
                bullets = new List<GameObject>();
                for (int i = 0; i < (360 / drone.surrounded_axis); i++)
                {
                    GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    bullet.transform.position = drone.transform.position;
                    bullet.GetComponent<Collider>().isTrigger = true;

                    current_axis += drone.surrounded_axis;
                    rot = Quaternion.AngleAxis(current_axis, drone.transform.up);
                    print("Rot : " + rot.eulerAngles);
                    current_rot = rot * drone.transform.forward;
                    print("Current : " + current_rot);
                    bullet.AddComponent<Rigidbody>().AddForce(current_rot * drone.bullet_force, ForceMode.Impulse);
                    bullets.Add(bullet);
                }
                
                yield return new WaitForSeconds(1);
            }
            
            while (time < speed)
            {
                drone.transform.position = Vector3.Lerp(startPosition, endPosition, time / speed);
                time += Time.deltaTime;

                yield return null;
            }
        }
    }
}