using UnityEngine;
 using System.Collections.Generic;

namespace GDD
{
    public class ClientStrategy : MonoBehaviour
    {
        [SerializeField] private float bullet_force = 100;
        [SerializeField] private int surrounded_axis = 15;
        private GameObject _drone;

        private List<IManeuverBehaviour>
            _components = new List<IManeuverBehaviour>();

        private List<IManeuverBehaviour> _bulletType = new List<IManeuverBehaviour>();

        private void SpawnDrone()
        {
            _drone =
                GameObject.CreatePrimitive(PrimitiveType.Cube);

            _drone.AddComponent<Drone_StrategyPattern>();
            _drone.GetComponent<Drone_StrategyPattern>().bullet_force = bullet_force;
            _drone.GetComponent<Drone_StrategyPattern>().surrounded_axis = surrounded_axis;
            _drone.transform.position =
                Random.insideUnitSphere * 10;

            ApplyRandomStrategies();
        }

        private void ApplyRandomStrategies()
        {
            _components.Add(
                _drone.AddComponent<WeavingManeuver>());
            _components.Add(
                _drone.AddComponent<BoppingManeuver>());
            _components.Add(
                _drone.AddComponent<FallbackManeuver>());

            int index = Random.Range(0, _components.Count);
            int index_bullet = Random.Range(0, _bulletType.Count);
            
            _drone.GetComponent<Drone_StrategyPattern>().ApplyStrategy(_components[index]);
        }

        void OnGUI()
        {
            if (GUILayout.Button("Spawn Drone"))
            {
                SpawnDrone();
            }
        }
    }
}