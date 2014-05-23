using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.NN.Activation
{
    class ActivationFunctionFactory
    {

        public static ActivationFunction CreateDefaultFunction()
        {
            return CreateFunction((ActivationFuctionType) Settings.Default.UsedActivationFunction);
        }

        public static ActivationFunction CreateFunction(ActivationFuctionType type) 
        {
            switch (type)
            {
                case ActivationFuctionType.Sigmoid:
                    return new Sigmoid();
                default:
                    return new Tanh();
            }
        }

    }
}
