using UnityEngine;

namespace GDD
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void Notify(Subject subject);
    }
}