using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{
    class FitnessFunctionFactory
    {

        public static FitnessFunction CreateDefaultFunction()
        {
            return CreateFunction((FitnessFunctionType) Settings.Default.UsedFitnessFunction);
        }

        public static FitnessFunction CreateFunction(FitnessFunctionType type)
        {
            switch (type)
            {
                case FitnessFunctionType.PositionToEnd:
                    return new FinalPosition();
                default:
                    return new FinalPosition();
            }
        }

    }
}
