using System;

namespace GDD
{
    public class Command_SpinRight : Command
    {
        public Command_SpinRight(BikeController3 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            n_execute = "SpinRight " + DateTime.Now;
            _controller.Spin(BikeController3.Direction.Right);
        }
    }
}