using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSimulationController.GA.Fitness
{
    class Tailored : FitnessFunction
    {

        public override float Calculate(EvaluationStatistics statistics)
        {
            float result = 0f;
            // Max position is measure of goal

            try
            {
                result += 7 * statistics.Position.Max();
                result += 5 * (statistics.MotorLeftValues.Average()
                                  + statistics.MotorRightValues.Average()) / 2;
            }
            catch (Exception e)
            {
            }
           
            return result;
        }
    }
}
