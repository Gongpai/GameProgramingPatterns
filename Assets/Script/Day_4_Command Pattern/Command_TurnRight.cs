using System;

namespace GDD
{
    public class Command_TurnRight : Command
    {
        public Command_TurnRight(BikeController3 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            n_execute = "TurnRight " + DateTime.Now;
            _controller.Turn(BikeController3.Direction.Right);
        }
    }
}