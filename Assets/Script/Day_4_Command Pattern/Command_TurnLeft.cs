using System;

namespace GDD
{
    public class Command_TurnLeft : Command
    {
        public Command_TurnLeft(BikeController3 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            n_execute = "TurnLeft " + DateTime.Now;
            _controller.Turn(BikeController3.Direction.Left);
        }
    }
}