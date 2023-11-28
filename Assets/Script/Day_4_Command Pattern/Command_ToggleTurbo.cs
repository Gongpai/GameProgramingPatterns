using System;

namespace GDD
{
    public class Command_ToggleTurbo : Command
    {
        public Command_ToggleTurbo(BikeController3 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            n_execute = "Turbo " + DateTime.Now;
            _controller.ToggleTurbo();
        }
    }
}