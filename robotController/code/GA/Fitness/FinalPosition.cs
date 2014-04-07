using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{
    class MaxPosition : FitnessFunction
    {

        public override float Calculate(EvaluationStatistics statistics)
        {
            return statistics.Position.Max();
        }
    }
}
