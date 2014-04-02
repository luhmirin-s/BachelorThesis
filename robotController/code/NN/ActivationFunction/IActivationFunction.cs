using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    interface IActivationFunction
    {
        float Compute(float value);
    }
}
