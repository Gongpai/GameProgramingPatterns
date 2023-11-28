using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDD
{
    public abstract class Command
    {
        protected BikeController3 _controller;
        
        public string n_execute;
        public abstract void Execute();

        public void set_controller(BikeController3 controller)
        {
            _controller = controller;
        }
    }
}