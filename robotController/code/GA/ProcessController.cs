using Moda;
using RobotSimulationController.GA;
using RobotSimulationController.GA.Crossovers;
using RobotSimulationController.GA.Fitness;
using RobotSimulationController.GA.Mutations;
using RobotSimulationController.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSimulationController
{

    class ProcessController
    {

        private int POPULATION_SIZE = Settings.Default.PopulationSize;

        private List<AbstractRobot> Population;

        private EvolutionThread Evolution;

        public ProcessController()
        {
        }

        public void SetRobotType(RobotType type, RobotPHX phx)
        {
            Population = new List<AbstractRobot>();

            switch (type)
            {
                case RobotType.SIMPLE_NN:
                    for (int ii = 0; ii < POPULATION_SIZE; ii++)
                    {
                        Population.Add(new RobotNN(phx));
                    }
                    break;
                default:
                    break;
            }
        }

        public void Start(Connection connection)
        {
            Console.WriteLine("### started evolution ###");

            Evolution = EvolutionThread.NewInstance()
                .WithConnection(connection)
                .WithPopulation(Population);

            Thread t = new Thread(Evolution.DoWork);
            t.Start();
        }

        public void Stop()
        {
            if (Evolution != null)
            {
                Evolution.RequestStop();
            }
        }

    }
}
