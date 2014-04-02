using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN.Activation
{
    class ClassicSigmoid : IActivationFunction
    {
        public float Compute(float value)
        {
            return (float)(1 / (1 + Math.Exp(-value)));
        }
    }
}
