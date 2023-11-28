using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace GDD
{
    public class ObjectAction : MonoBehaviour
    {
        public IObjectPool<ObjectAction> Pool { get; set; }

        public float _currentHealth;

        [SerializeField] private float maxHealth = 100.0f;
        [SerializeField] private float timeToSelfDestruct = 3.0f;

        void Start()
        {
            _currentHealth = maxHealth;
        }

        void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        private void OnDisable()
        {
            ResetObject();
        }

        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }

        protected virtual void ReturnToPool()
        {
            print("Pool : " + (Pool == null));
            
            Pool.Release(this);
        }

        protected virtual void ResetObject()
        {
            _currentHealth = maxHealth;
            gameObject.transform.position = Vector3.zero;
        }

        public virtual void AttackPlayer()
        {
            Debug.Log("Attack player!");
        }

        public virtual void TakeDamage(float amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0.0f)
                ReturnToPool();
        }
    }
}