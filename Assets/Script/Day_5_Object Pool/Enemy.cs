using System;
using UnityEngine;

namespace GDD
{
    public class Enemy : ObjectAction
    {
        private Vector3 rot;

        public Vector3 rot_vector
        {
            get => rot;
            set => rot = value;
        }
        
        protected override void ResetObject()
        {
            base.ResetObject();
        }

        protected override void ReturnToPool()
        {
            base.ReturnToPool();
        }

        public override void AttackPlayer()
        {
            base.AttackPlayer();
        }

        public override void TakeDamage(float amount)
        {
            
        }

        private void Update()
        {
            transform.RotateAround(transform.position, Vector3.Scale(rot, Vector3.one * 50), 50 * Time.deltaTime);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
        }
    }
}