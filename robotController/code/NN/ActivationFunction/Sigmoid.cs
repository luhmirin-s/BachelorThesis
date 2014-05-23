using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN.Activation
{
    class Sigmoid : ActivationFunction
    {
        public override float Compute(float value)
        {
            return (float)(1 / (1 + 3 * Math.Exp(-3 * value)));
        }
    }
}
