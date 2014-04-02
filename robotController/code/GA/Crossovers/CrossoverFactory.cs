using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Crossovers
{
    class CrossoverFactory
    {

        public static Crossover CreateDefaultCrossover()
        {
            return CreateCrossover((CrossoverType)Settings.Default.UsedCrossover);
        }

        public static Crossover CreateCrossover(CrossoverType type)
        {
            switch (type)
            {
                case CrossoverType.UniformWithElite:
                    return new UniformWithElite();
                default:
                    return new UniformWithElite();
            }
        }

    }
}
