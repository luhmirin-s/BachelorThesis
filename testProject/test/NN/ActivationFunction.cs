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

    class ClassicSigmoid : IActivationFunction
    {

        public float Compute(float value)
        {
            return (float)(1 / (1 + Math.Exp(-value)));
        }
    }

    class Sigmoid : IActivationFunction
    {
        // Making classic sigmoid range [-1,1
        // Function returns negative results only if value is < ~0.2
        public float Compute(float value)
        {
            return (float)((2 / (1 + 2 * Math.Exp(-5 * value))) - 1);
        }
    }
}
