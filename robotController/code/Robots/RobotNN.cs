using Moda;
using RobotSimulationController.GA;
using RobotSimulationController.NN;
using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSimulationController
{
    class RobotNN : AbstractRobot
    {

        private AbstractNN Network;

        public override Genome Genotype
        {
            get { return base.Genotype; }
            set
            {
                base.Genotype = value;
                Network = NetworkFactory.CreateDefaultNetwork(Genotype.GetWeights());
            }
        }

        public RobotNN(RobotPHX robot, Genome genome)
        {
            Robot = robot;
            Genotype = genome;
            Network = NetworkFactory.CreateDefaultNetwork(Genotype.GetWeights());
        }

        public RobotNN(RobotPHX robot)
        {
            Robot = robot;
            Network = NetworkFactory.CreateDefaultNetwork(new float[] {});
            Genotype = new Genome(Network.Weights);
            
        }

        public override void ComputeStep()
        {

            float[] sensors = GetSensorReadings();

            float[] results = Network.SetInputValuesAndCompute(sensors);

          //  Console.WriteLine(sensors[0] + " " + sensors[1] + " | " + results[0] + " " + results[1]);
            // Here we send motor speeds to form.
            SetNewMotorSpeeds(results);
            PostPosition();

            Robot.GetConnection().Sleep(150);
        }

        public override String GetWeightsAsString()
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

        public override AbstractRobot Clone()
        {
            return new RobotNN(Robot, Genotype);
        }

    }
}