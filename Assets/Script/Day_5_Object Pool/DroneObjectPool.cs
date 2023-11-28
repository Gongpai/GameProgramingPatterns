using System;
using UnityEngine;

namespace GDD
{
    public class DroneObjectPool : ObjectPool
    {
        protected override ObjectAction CreatedPooledItem()
        {
            return base.CreatedPooledItem();
        }

        protected override void CreatePrimitive(out ObjectAction go)
        {
            GameObject _object = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _object.name = "Drone";
            go = _object.AddComponent<Drone>();
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
            base.Spawn();
        }
    }
}