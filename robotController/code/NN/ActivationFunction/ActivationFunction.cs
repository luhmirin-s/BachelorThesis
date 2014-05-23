using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN
{
    abstract class ActivationFunction
    {
        public abstract float Compute(float value);
    }
}
