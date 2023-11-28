using UnityEngine;
 using System.Collections;

namespace GDD
{
    public class WeavingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        private GameObject bullet;
        
        public void Maneuver(Drone_StrategyPattern drone)
        {
            StartCoroutine(Weave(drone));
        }

        IEnumerator Weave(Drone_StrategyPattern drone)
        {
            float time;
            bool isReverse = false;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.x = drone.weavingDistance;
            
            while (true)
            {
                time = 0;
                Vector3 start = drone.transform.position;
                Vector3 end =
                    (isReverse) ? startPosition : endPosition;
                
                if(bullet != null)
                    Destroy(bullet);
            
                bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                bullet.transform.position = drone.transform.position;
                bullet.AddComponent<Rigidbody>().AddForce(drone.transform.forward * drone.bullet_force, ForceMode.Impulse);

                while (time < speed)
                {
                    drone.transform.position = Vector3.Lerp(start, end, time / speed);

                    time += Time.deltaTime;

                    yield return null;
                }

                yield return new WaitForSeconds(1);
                isReverse = !isReverse;
            }
        }
    }
}
