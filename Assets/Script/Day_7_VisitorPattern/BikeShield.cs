using UnityEngine;

namespace GDD
{
    public class BikeShield : MonoBehaviour, IVisitableBikeElement
    {
        public float health = 50.0f; // Percentage

        public float Damage(float damage)
        {
            health -= damage;
            return health;
        }

        public void Accept(IBikeElementVisitor visitor)
        {
            visitor.Visit(this);
        }

        void OnGUI()
        {
            GUI.color = Color.green;

            GUI.Label(
                new Rect(125, 0, 200, 20),
                "Shield Health: " + health);
        }
    }
}