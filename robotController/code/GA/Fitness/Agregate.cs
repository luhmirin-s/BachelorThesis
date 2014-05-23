using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{

    /// <summary>
    /// Returns the max value from position statistics.
    /// </summary>
    class Aggregate : FitnessFunction
    {

        public override float Calculate(EvaluationStatistics statistics)
        {
            float result = 0;

            try
            {
                result = statistics.Position.Max();
            }
            catch (Exception e)
            {
                result = 0;
            }

            return result;
            
        }
    }
}
