using System.Collections.Generic;
 using UnityEngine;

namespace GDD
{
    public class BikeControllerVisitorPattern : MonoBehaviour, IVisitableBikeElement
    {
        private List<IVisitableBikeElement> _bikeElements = new List<IVisitableBikeElement>();

        void Start()
        {
            _bikeElements.Add(gameObject.AddComponent<BikeShield>());
            _bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
            _bikeElements.Add(gameObject.AddComponent<BikeEngine>());
            _bikeElements.Add(gameObject.AddComponent<BikeColor>());
        }

        public void Accept(IBikeElementVisitor visitor)
        {
            foreach (IVisitableBikeElement element in _bikeElements)
            {
                element.Accept(visitor);
            }
        }
    }


}