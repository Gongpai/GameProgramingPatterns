using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public interface IManeuverBehaviour
    {
        void Maneuver(Drone_StrategyPattern drone);
    }
}