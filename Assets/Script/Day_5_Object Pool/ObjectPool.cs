using UnityEngine;
using UnityEngine.Pool;

namespace GDD
{
    public class ObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;

        private IObjectPool<ObjectAction> _pool;
        public IObjectPool<ObjectAction> Pool
        {
            get
            {
                if (_pool == null)
                    _pool =
                        new ObjectPool<ObjectAction>(CreatedPooledItem,
                            OnTakeFromPool,
                            OnReturnedToPool,
                            OnDestroyPoolObject,
                            true,
                            stackDefaultCapacity,
                            maxPoolSize);
                return _pool;
            }
        }

        protected virtual ObjectAction CreatedPooledItem()
        {
            CreatePrimitive(out ObjectAction go);
            ObjectAction objectAction = go;
            objectAction.Pool = Pool;
            return objectAction;
        }

        protected virtual void CreatePrimitive(out ObjectAction go)
        {
            GameObject _object;
            _object = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _object.name = "Drone";
            go = _object.AddComponent<ObjectAction>();
        }

        protected virtual void OnReturnedToPool(ObjectAction objectAction)
        {
            objectAction.gameObject.SetActive(false);
        }

        protected virtual void OnTakeFromPool(ObjectAction objectAction)
        {
            objectAction.gameObject.SetActive(true);
        }

        protected virtual void OnDestroyPoolObject(ObjectAction objectAction)
        {
            Destroy(objectAction.gameObject);
        }

        public virtual void Spawn()
        {
            var amount = Random.Range(1, 10);

            for (int i = 0; i < amount; ++i)
            {
                var drone = Pool.Get();
                drone.transform.position =
                    Random.insideUnitSphere * 10;
            }
        }
    }
}