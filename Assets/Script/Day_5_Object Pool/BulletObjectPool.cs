using Unity.VisualScripting;
using UnityEngine;

namespace GDD
{
    public class BulletObjectPool : ObjectPool
    {
        protected override ObjectAction CreatedPooledItem()
        {
            return base.CreatedPooledItem();
        }

        protected override void CreatePrimitive(out ObjectAction go)
        {
            GameObject _object = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            _object.transform.localScale = new Vector3(0.5f, 1, 0.5f);
            _object.name = "Bullet";
            go = _object.AddComponent<Bullet>();
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
                
                Rigidbody rigidbody;
                if (drone.GetComponent<Rigidbody>() == null)
                {
                    rigidbody = drone.AddComponent<Rigidbody>();
                    rigidbody.useGravity = false;
                }
                else
                {
                    rigidbody = drone.GetComponent<Rigidbody>();
                }

                rigidbody.AddForce(Random.insideUnitSphere * 10, ForceMode.Impulse);
            }
        }
    }
}