using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public class ClientObjectPool : MonoBehaviour
    {
        private DroneObjectPool _dronepool;
        private BulletObjectPool _bulletpool;
        private EnemyObjectPool _enemypool;

        void Start()
        {
            _dronepool = gameObject.AddComponent<DroneObjectPool>();
            _bulletpool = gameObject.AddComponent<BulletObjectPool>();
            _enemypool = gameObject.AddComponent<EnemyObjectPool>();
        }

        void OnGUI()
        {
            if (GUILayout.Button("Spawn Drones"))
                _dronepool.Spawn();
            
            if (GUILayout.Button("Spawn Bullets"))
                _bulletpool.Spawn();
            
            if (GUILayout.Button("Spawn Enemy"))
                _enemypool.Spawn();
        }
    }
}