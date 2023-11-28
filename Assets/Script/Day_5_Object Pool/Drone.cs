namespace GDD
{
    public class Drone : ObjectAction
    {
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
            base.TakeDamage(amount);
        }
    }
}