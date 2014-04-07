using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{
    abstract class FitnessFunction
    {

        public abstract float Calculate(EvaluationStatistics statistics);

    }
}
