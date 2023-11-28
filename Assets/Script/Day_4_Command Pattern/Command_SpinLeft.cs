using System;

namespace GDD
{
    public class Command_SpinLeft : Command
    {
        public Command_SpinLeft(BikeController3 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            n_execute = "SpinLeft " + DateTime.Now;
            _controller.Spin(BikeController3.Direction.Left);
        }
    }
}