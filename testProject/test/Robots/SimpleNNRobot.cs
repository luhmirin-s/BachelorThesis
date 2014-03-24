using Moda;
using RobotSimulationController.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSimulationController
{
    class SimpleNNRobot : AbstractRobot
    {

        private SimpleNN Network;

        public SimpleNNRobot(RobotPHX robot)
        {
            Robot = robot;
            Network = new SimpleNN();

        }

        public override void ComputeStep()
        {

            float[] sensors = GetSensorReadings();

            float[] results = Network.SetInputValuesAndCompute(sensors);

            // Here we send motor speeds to form.
            SetNewMotorSpeeds(results);
            PostPosition();

            Robot.GetConnection().Sleep(150);
        }

        public override String GetWeights()
        {
            float[] weights = Network.Weights;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Weights: ");
            foreach (float w in weights)
            {
                sb.AppendLine(w.ToString());
            }

            return sb.ToString();
        }
    }
}