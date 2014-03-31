using Moda;
using RobotSimulationController.GA;
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

        public SimpleNNRobot(RobotPHX robot, Genome genome)
        {
            Robot = robot;
            Genotype = genome;
            Network = new SimpleNN(Genotype.getWeights());
        }

        public SimpleNNRobot(RobotPHX robot)
        {
            Robot = robot;
            Genotype = new Genome(SimpleNN.getRandomizedWeights());
            Network = new SimpleNN(Genotype.getWeights());
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

        public override Genome getGenome()
        {
            return base.getGenome();
        }

        public override void setGenome(Genome genome)
        {
            base.setGenome(genome);
            Network = new SimpleNN(Genotype.getWeights());
        }

        public override AbstractRobot Clone()
        {
            return new SimpleNNRobot(this.Robot, this.getGenome());
        }
    }
}