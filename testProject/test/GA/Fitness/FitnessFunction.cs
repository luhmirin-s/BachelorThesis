using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{
    interface FitnessFunction
    {

        float Calculate(AbstractRobot robot, float[] data);

    }
}
