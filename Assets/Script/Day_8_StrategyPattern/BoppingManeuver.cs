using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GDD
{
    public class BoppingManeuver :
        MonoBehaviour, IManeuverBehaviour
    {
        private List<GameObject> bullets = new List<GameObject>();
        
        public void Maneuver(Drone_StrategyPattern drone)
        {
            StartCoroutine(Bopple(drone));
        }

        IEnumerator Bopple(Drone_StrategyPattern drone)
        {
            float time;
            bool isReverse = false;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.y = drone.maxHeight;
            while (true)
            {
                time = 0;
                Vector3 start = drone.transform.position;
                Vector3 end =
                    (isReverse) ? startPosition : endPosition;

                if (bullets.Count > 0)
                {
                    foreach (var _bullet in bullets)
                    {
                        Destroy(_bullet);
                    }
                }


                bullets = new List<GameObject>();
                for (int i = 0; i < 3; i++)
                {
                    GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    bullet.transform.position = drone.transform.position;
                    bullet.GetComponent<Collider>().isTrigger = true;
                    bullets.Add(bullet);
                }
                
                bullets[0].AddComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1)* drone.bullet_force, ForceMode.Impulse);
                bullets[1].AddComponent<Rigidbody>().AddForce(new Vector3(1, 0, 1) * drone.bullet_force, ForceMode.Impulse);
                bullets[2].AddComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 1) * drone.bullet_force, ForceMode.Impulse);

                while (time < speed)
                {
                    drone.transform.position =
                        Vector3.Lerp(start, end, time / speed);
                    time += Time.deltaTime;
                    yield return null;
                }

                yield return new WaitForSeconds(1);
                isReverse = !isReverse;
            }
        }
    }
}