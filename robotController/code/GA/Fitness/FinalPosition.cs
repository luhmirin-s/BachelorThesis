using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{
    class FinalPosition : FitnessFunction
    {

        public override float Calculate(AbstractRobot robot, float[] data)
        {
            return robot.GetPosition().X;
        }
    }
}
