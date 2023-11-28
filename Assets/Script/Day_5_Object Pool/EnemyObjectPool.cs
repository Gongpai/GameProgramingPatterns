using Unity.VisualScripting;
using UnityEngine;

namespace GDD
{
    public class EnemyObjectPool : ObjectPool
    {
        protected override ObjectAction CreatedPooledItem()
        {
            return base.CreatedPooledItem();
        }

        protected override void CreatePrimitive(out ObjectAction go)
        {
            GameObject _object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _object.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            _object.name = "Drone";
            go = _object.AddComponent<Enemy>();
        }
        
        protected override void OnReturnedToPool(ObjectAction objectAction)
        {
            base.OnReturnedToPool(objectAction);
        }

        protected override void OnTakeFromPool(ObjectAction objectAction)
        {
            base.OnTakeFromPool(objectAction);
        }

        protected override void OnDestroyPoolObject(ObjectAction objectAction)
        {
            base.OnDestroyPoolObject(objectAction);
        }

        public override void Spawn()
        {
            var amount = Random.Range(2, 10);

            for (int i = 0; i < amount; ++i)
            {
                var drone = Pool.Get();

                Vector3 rot_vector = Random.insideUnitSphere * 360;
                drone.transform.localEulerAngles = rot_vector;

                drone.GetComponent<Enemy>().rot_vector = rot_vector;
            }
        }
    }
}